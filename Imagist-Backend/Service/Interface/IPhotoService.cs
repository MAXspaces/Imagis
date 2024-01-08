using Imagist_Library.Apis;
using Imagist_Library.Apis.PhotoApi;

namespace Imagist_Backend.Service.Interface;

public interface IPhotoService
{
    Task<Api<long>> UploadPhoto(long userId, long albumId, IFormFile file);
    Api<object> DeletePhoto(long userId, long photoId);
    Api<object> RestorePhoto(long userId, long photoId);
    Api<object> PermanentDeletePhoto(long userId, long photoId);
    Api<List<PhotoDto>> GetUserPhotos(long userId);
    Api<List<PhotoDto>> GetDeletedPhoto(long userId);
}