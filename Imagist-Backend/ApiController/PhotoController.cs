using Imagist_Backend.Service.Interface;
using Imagist_Library.Apis;
using Imagist_Library.Apis.PhotoApi;
using Imagist_Library.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Imagist_Backend.ApiController;
[ApiController]
[Route("[controller]/")]
public class PhotoController : Controller
{
    private readonly IPhotoService _photoService;
    private readonly ILogger<PhotoController> _logger;

    [HttpPost,Authorize]
    public Task<Api<long>> UploadPhoto(IFormFile file,[FromQuery]long albumId)
    {
        var userId = this.GetUserId();
        var username = this.GetUserName();
        return _photoService.UploadPhoto(userId, albumId, file);

    }

    [HttpDelete, Authorize]
    public Api<object> DeletePhoto([FromQuery] long photoId)
    {
        var userId = this.GetUserId();
        return  _photoService.DeletePhoto(userId, photoId);
    }

    [HttpGet("deleted"), Authorize]
    public Api<List<PhotoDto>> GetDeletedPhoto()
    {
        var userId = this.GetUserId();
        return _photoService.GetDeletedPhoto(userId);
    }

    [HttpPost("restore"), Authorize]
    public Api<object> RestorePhoto([FromQuery] long photoId)
    {
        var userId = this.GetUserId();
        return  _photoService.RestorePhoto(userId, photoId);
    }
    
    [HttpDelete("permanent"), Authorize]
    public Api<object> PermanentDeletePhoto([FromQuery] long photoId)
    {
        var userId = this.GetUserId();
        return  _photoService.PermanentDeletePhoto(userId, photoId);
    }
    
    //获取用户所有照片
    [HttpGet("all"), Authorize]
    public Api<List<PhotoDto>> GetUserPhoto()
    {
        var userId = this.GetUserId();
        return _photoService.GetUserPhotos(userId);
    }

    public PhotoController(IPhotoService photoService,ILogger<PhotoController> logger)
    {
        _photoService = photoService;
        _logger = logger;
    }
}