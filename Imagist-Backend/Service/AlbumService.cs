using Flurl;
using Imagist_Backend.Data;
using Imagist_Backend.Service.Interface;
using Imagist_Library.Apis;
using Imagist_Library.Apis.AlbumApi;
using Imagist_Library.Apis.PhotoApi;
using Imagist_Library.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Snowflake.Core;

namespace Imagist_Backend.Service;

public class AlbumService : IAlbumService
{
    private readonly DataContext _dataContext;
    private readonly IdWorker _idWorker;
    private readonly string _objectServerEndpoint;
    public readonly string _imageBucket;

    public Api<List<AlbumDto>> GetUserAlbums(long userId)
    {
        if (_dataContext.Users.Where(u=>u.UserId == userId).IsNullOrEmpty())
        {
            return Api<List<AlbumDto>>.Failed(ApiCode.NotFound,"无当前用户"); 
        }

        var albums = _dataContext.Albums
            .Where(a=>a.OwingUser.UserId.Equals(userId))
            .Select(a=>new AlbumDto()
            {
                AlbumId = a.AlbumId,
                AlbumName = a.AlbumName,
                AlbumDescription = a.AlbumDescription
            })
            .ToList();
        return Api<List<AlbumDto>>.Success(albums,"相册获取成功");
    }

    public Api<long> CreateAlbum(long userId, CreateAlbumRequest request)
    {
        Album newAlbum = new Album()
        {
            AlbumId = _idWorker.NextId(),
            AlbumName = request.AlbumName,
            AlbumDescription = request.AlbumDescription,
            OwingUserId = userId
        };
        _dataContext.Albums.Add(newAlbum);
        _dataContext.SaveChanges();
        return Api<long>.Success(newAlbum.AlbumId,"相册新建成功");
    }

    public Api<object> ModifyAlbum(long userId, AlbumDto albumDto)
    {
        //附带校验该相册是否属于该用户
        var album = _dataContext.Albums.FirstOrDefault(a => a.AlbumId == albumDto.AlbumId && a.OwingUserId == userId);
        if (album is null)
        {
            return Api<object>.Failed(ApiCode.NotFound, "当前相册不存在");
        }

        album.AlbumName = albumDto.AlbumName is null ? album.AlbumName : albumDto.AlbumName;
        album.AlbumDescription = albumDto.AlbumDescription is null ? album.AlbumDescription : albumDto.AlbumDescription;

        _dataContext.SaveChanges();
        return Api<object>.Success("相册修改成功");
    }

    public Api<object> DeleteAlbum(long userId, long albumId)
    {
        //附带校验该相册是否属于该用户
        var album = _dataContext.Albums.FirstOrDefault(a => a.AlbumId == albumId && a.OwingUserId == userId);
        if (album is null)
        {
            return Api<object>.Failed(ApiCode.NotFound,"该相册不存在");
        }
        _dataContext.Albums.Remove(album);
        _dataContext.SaveChanges();
        return Api<object>.Success("相册删除成功");
    }

    public Api<List<PhotoDto>> GetAlbumPhotos(long userId,long albumId)
    {
        var album = _dataContext.Albums.FirstOrDefault(a => a.AlbumId == albumId && a.OwingUserId == userId);
        if (album is null)
        {
            return Api<List<PhotoDto>>.Failed(ApiCode.NotFound,"该相册不存在");
        }

        var photos = _dataContext.Photos
            .AsNoTracking()
            .Where(p => p.AlbumId == albumId && p.OwingUserId == userId && p.Delete==false)
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

    public AlbumService(DataContext dataContext,IdWorker idWorker,IConfiguration configuration)
    {
        _dataContext = dataContext;
        _idWorker = idWorker;
        _objectServerEndpoint = configuration.GetSection("APP:MinIO:Url").Value!;
        _imageBucket = configuration.GetSection("APP:MinIO:Bucket:Image").Value!;
    }
}