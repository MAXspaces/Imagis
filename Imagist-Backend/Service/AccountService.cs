using ImageMagick;
using Imagist_Backend.Data;
using Imagist_Backend.Service.Interface;
using Imagist_Library.Apis.UserApi;
using Imagist_Library.Apis;
using Imagist_Library.Apis.UserApi.Login;
using Imagist_Library.Apis.UserApi.Register;
using Imagist_Library.Authentication;
using Imagist_Library.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Minio;
using Minio.DataModel.Args;
using Snowflake.Core;
using BCryptEncoder = BCrypt.Net.BCrypt; 

namespace Imagist_Backend.Service;

public class AccountService:IAccountService
{
    private IdWorker _idWorker;
    private readonly JwtHelper _jwtHelper;
    private readonly DataContext _dataContext;
    private readonly IMinioClient _minioClient;
    private readonly IObjectStorageService _objectStorageService;
    private readonly string _objectServerEndpoint;
    private readonly string _imageBucket;

    public async Task<Api<RegisterResponse>> Register(RegisterRequest request, IFormFile userProfile)
    {
        var user = _dataContext.Users.FirstOrDefault(u => u.Email.Equals(request.Email));
        if (user != null)
        {
          return  Api<RegisterResponse>.Failed(ApiCode.Existed,"该邮件已被注册");
        }

        var encodedPassword = BCryptEncoder.HashPassword(request.Password);
        //上传用户头像
        
        var profileId = $"small-IM-{Guid.NewGuid()}.jpg";
        var newUser = new User(_idWorker.NextId(), request.UserName, request.Email, encodedPassword, profileId);

        
        uploadUserProfile(userProfile,profileId);
        _dataContext.Users.Add(newUser);
        _dataContext.SaveChanges();
        
        
        return Api<RegisterResponse>.Success("注册成功");
    }

    public Api<LoginResponse> Login(LoginRequest request)
    {
        var user = _dataContext.Users.FirstOrDefault(u => u.Email.Equals(request.Email));
        if (user == null || !BCryptEncoder.Verify(request.Password,user.Password))
        {
            return Api<LoginResponse>.Failed(ApiCode.LoginFailed,"用户账号或密码不正确");
        }
        //生成jwt Token并且返回
        var response = new LoginResponse()
        {
            JwtToken = _jwtHelper.CreateToken(user),
            profileUrl =  $"http://{_objectServerEndpoint}/{_imageBucket}/{user.ProfileId}"
        };
        return Api<LoginResponse>.Success(response, "登录成功");
    }

    private async void uploadUserProfile(IFormFile file,string profileId)
    {
        using (MagickImage image = new MagickImage(file.OpenReadStream()))
        {
            image.Format = MagickFormat.Jpeg; // 设置图像格式
            image.Resize(200, 200*image.Height/image.Width); // 调整图像大小
            image.Quality = 80; // 设置压缩质量
            // 保存压缩后的图像到临时文件;
            image.Write("./" + profileId);
            // 现在你可以使用 tempFilePath 进行上传操作
        }
        //上传文件
        using (Stream stream = new FileInfo("./" + profileId).OpenRead())
        {
            _objectStorageService.UploadObject(_imageBucket,profileId,stream);
        }
        //删除临时文件
        new FileInfo("./" + profileId).Delete();
        
    }
    
    public AccountService(
        IdWorker idWorker,
        JwtHelper jwtHelper,
        DataContext dataContext,
        IMinioClient minioClient,
        IConfiguration configuration, 
        IObjectStorageService objectStorageService)
    {
        _idWorker = idWorker;
        _jwtHelper = jwtHelper;
        _dataContext = dataContext;
        _minioClient = minioClient;
        _objectStorageService = objectStorageService;
        _objectServerEndpoint = configuration.GetSection("APP:MinIO:Url").Value!;
        _imageBucket = configuration.GetSection("APP:MinIO:Bucket:Image").Value!;
    }
    
}