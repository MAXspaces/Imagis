namespace Imagist_Backend.Service.Interface;

public interface IObjectStorageService
{
    public void BucketExistingCheck(string bucketName);
    public Task UploadObject(string bucketName, string objectId, Stream stream);
    public Task<string> GetObjectUrl(string objectName, string bucketName);
    public Task DeleteObject(string objectName, string bucketName);
}