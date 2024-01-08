using Imagist_Library.Apis;
using Imagist_Library.Apis.AlbumApi;
using Imagist_Library.Apis.PhotoApi;

namespace Imagist_Backend.Service.Interface;

public interface IAlbumService
{
    Api<List<AlbumDto>> GetUserAlbums(long userId);
    Api<long> CreateAlbum(long userId, CreateAlbumRequest request);
    Api<object> ModifyAlbum(long userId, AlbumDto albumDto);
    Api<object> DeleteAlbum(long userId, long albumId);
    Api<List<PhotoDto>> GetAlbumPhotos(long userId,long albumId);
}