using Imagist_Backend.Service.Interface;
using Imagist_Library.Apis;
using Imagist_Library.Apis.AlbumApi;
using Imagist_Library.Apis.PhotoApi;
using Imagist_Library.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Imagist_Backend.ApiController;

[ApiController]
[Microsoft.AspNetCore.Mvc.Route("[controller]/")]
public class AlbumController:Controller
{
    private readonly IAlbumService _albumService;

    [HttpGet("all"),Authorize]
    public Api<List<AlbumDto>> GetUserAlbums()
    {
        var userId = this.GetUserId();
        return _albumService.GetUserAlbums(userId);
    }

    [HttpPut,Authorize]
    public Api<long> CreateAlbum([FromBody] CreateAlbumRequest request)
    {
        var userId = this.GetUserId();
        return _albumService.CreateAlbum(userId,request);
    }
    
    [HttpPost,Authorize]
    public Api<object> ModifyAlbum([FromBody] AlbumDto albumDto)
    {
        var userId = this.GetUserId();
        return _albumService.ModifyAlbum(userId, albumDto);
    }
    [HttpDelete,Authorize]
    public Api<object> DeleteAlbum([FromQuery(Name = "albumId")] long albumId)
    {
        Console.WriteLine($"albumnId--{albumId}");
        var userId = this.GetUserId();
        return _albumService.DeleteAlbum(userId, albumId);
    }

    [HttpGet("{album_id}/photos"),Authorize]
    public Api<List<PhotoDto>> GetAlbumPhotos([FromRoute(Name = "album_id")] long albumId)
    {
        var userId = this.GetUserId();
        return _albumService.GetAlbumPhotos(userId,albumId);
    }

    public AlbumController(IAlbumService albumService)
    {
        _albumService = albumService;
    }
}