using System.IO.Pipes;
using System.Text;
using System.Text.Json;
using ImageMagick;
using Imagist_Backend.Data;
using Imagist_Backend.Service.Interface;
using Imagist_Library.Apis;
using Imagist_Library.Apis.PhotoApi;
using Imagist_Library.Model;
using Imagist_Library.Photo;
using MetadataExtractor;
using Microsoft.EntityFrameworkCore;
using Minio;
using Minio.DataModel.Args;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using Snowflake.Core;

namespace Imagist_Backend.Service;

public class PhotoService : IPhotoService
{
    private readonly ILogger<PhotoService> _logger;
    private readonly IMinioClient _minioClient;
    private readonly IdWorker _idWorker;
    private readonly DataContext _dataContext;
    private readonly IObjectStorageService _objectStorageService;
    private readonly string _objectServerEndpoint;
    //Image bucket
    private readonly string _imageBucket;
    
    

    public void ConvertStream(Stream inputStream, out Stream outputStream)
    {
        MemoryStream memoryStream = new MemoryStream();
        inputStream.CopyTo(memoryStream);
        outputStream = memoryStream;
    }
    public async Task<Api<long>> UploadPhoto(long userId, long albumId,IFormFile file)
    {
        //解析照片的EXIF信息
        var metaData = PhotoExtractor.ExtractPhotoMetaData(file);
        
        //上传原图
        var photoUUid = Guid.NewGuid();
        var objectId = $"IM-{photoUUid}.{metaData.FileExtensionName}";
        _objectStorageService.UploadObject(_imageBucket,objectId,file.OpenReadStream());
        
        //同时生成压缩版本的照片
        var compressedObjectId = $"small-IM-{photoUUid}.jpg";
        using (MagickImage image = new MagickImage(file.OpenReadStream()))
        {
            image.Format = MagickFormat.Jpeg; // 设置图像格式
            image.Resize(1600, 1600*image.Height/image.Width); // 调整图像大小
            image.Quality = 50; // 设置压缩质量
            // 保存压缩后的图像到临时文件;
            image.Write("./" + compressedObjectId);
            // 现在你可以使用 tempFilePath 进行上传操作
        }
        //上传文件
        using (var stream = new FileInfo("./" + compressedObjectId).OpenRead())
        { 
            //上传需要使用await 避免在上传前或上传时输入流被自动关闭
            await _objectStorageService.UploadObject(_imageBucket,compressedObjectId,stream);
        }
        new FileInfo("./"+compressedObjectId).Delete();
        var newPhoto = new Photo()
        {
            PhotoId = _idWorker.NextId(),
            ObjectId = objectId,
            ThumbnailObjectId = compressedObjectId,
            OwingUserId = userId,
            MetaData = metaData,
            AlbumId = albumId,
            Delete = false,
        };
        _dataContext.Photos.Add(newPhoto);
        await _dataContext.SaveChangesAsync();
        
        return Api<long>.Success(newPhoto.PhotoId,"上传成功");
    }

    public Api<object> DeletePhoto(long userId, long photoId)
    {
        var photo = _dataContext.Photos
            .FirstOrDefault(p => p.PhotoId == photoId && p.OwingUserId == userId && p.Delete == false);
        if (photo is null)
        {
            return Api<object>.Failed(ApiCode.NotFound,"当前照片不存在");
        }

        photo.Delete = true;
        _dataContext.SaveChanges();
        return Api<object>.Success("照片删除成功");
    }

    public Api<object> RestorePhoto(long userId, long photoId)
    {
        var photo = _dataContext.Photos
            .FirstOrDefault(p => p.PhotoId == photoId && p.OwingUserId == userId && p.Delete == true);
        if (photo is null)
        {
            return Api<object>.Failed(ApiCode.NotFound,"当前照片不存在");
        }

        photo.Delete = false;
        _dataContext.SaveChanges();
        return Api<object>.Success("照片恢复成功");
    }

    public Api<object> PermanentDeletePhoto(long userId, long photoId)
    {
        var photo = _dataContext.Photos
            .FirstOrDefault(p => p.PhotoId == photoId && p.OwingUserId == userId && p.Delete == true);
        if (photo is null)
        {
            return Api<object>.Failed(ApiCode.NotFound,"当前照片不存在");
        }

        _dataContext.Photos.Remove(photo);
        _dataContext.SaveChanges();
        return Api<object>.Success("照片永久删除成功");
    }

    public Api<List<PhotoDto>> GetUserPhotos(long userId)
    {
        var photos = _dataContext.Photos
            .AsNoTracking()
            .Where(p => p.OwingUserId == userId && !p.Delete)
            .Select(p => new PhotoDto()
            {
                PhotoId = p.PhotoId,
                AlbumId = p.AlbumId,
                MetaData = p.MetaData,
                Url =_objectStorageService.GetObjectUrl(p.ObjectId,_imageBucket).Result,// $"http://{_objectServerEndpoint}/{_imageBucket}/{p.ObjectId}",
                ThumbnailObjectUrl = _objectStorageService.GetObjectUrl(p.ThumbnailObjectId,_imageBucket).Result,//$"http://{_objectServerEndpoint}/{_imageBucket}/{p.ThumbnailObjectId}"
            })
            .ToList();
        return Api<List<PhotoDto>>.Success(photos);
    }

    public Api<List<PhotoDto>> GetDeletedPhoto(long userId)
    {
        var photos = _dataContext.Photos
            .AsNoTracking()
            .Where(p => p.Delete && p.OwingUserId == userId)
            .Select(p => new PhotoDto()
            {
                PhotoId = p.PhotoId,
                AlbumId = p.AlbumId,
                MetaData = p.MetaData,
                Url = $"http://{_objectServerEndpoint}/{_imageBucket}/{p.ObjectId}",
                ThumbnailObjectUrl = $"http://{_objectServerEndpoint}/{_imageBucket}/{p.ThumbnailObjectId}"
            })
            .ToList();
        return Api<List<PhotoDto>>.Success(photos);
    }

    public PhotoService(ILogger<PhotoService> logger,
        IMinioClient minioClient,
        IdWorker idWorker,
        DataContext dataContext,
        IConfiguration configuration,
        IObjectStorageService objectStorageService)
    {
        _logger = logger;
        _minioClient = minioClient;
        _idWorker = idWorker;
        _dataContext = dataContext;
        _objectStorageService = objectStorageService;
        _objectServerEndpoint = configuration.GetSection("APP:MinIO:Url").Value!;
        _imageBucket = configuration.GetSection("APP:MinIO:Bucket:Image").Value!;
    }
    
}