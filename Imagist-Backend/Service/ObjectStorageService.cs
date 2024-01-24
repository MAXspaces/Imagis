using Minio;
using Minio.DataModel.Args;
using Minio.DataModel.Response;

namespace Imagist_Backend.Service.Interface;

public class ObjectStorageService : IObjectStorageService
{
    private readonly IMinioClient _minioClient;

    /// <summary>
    /// 检查文件桶是否存在，若否，创建文件桶
    /// </summary>
    /// <param name="bucketName">文件桶名称</param>
    public async void BucketExistingCheck(string bucketName)
    {
        var beArgs = new BucketExistsArgs()
            .WithBucket(bucketName);
        var found = await _minioClient.BucketExistsAsync(beArgs).ConfigureAwait(false);
        if (!found)
        {
            var mbArgs = new MakeBucketArgs()
                .WithBucket(bucketName);
            await _minioClient.MakeBucketAsync(mbArgs).ConfigureAwait(false);
        }
    }

    /// <summary>
    /// 将对象上传到文件桶
    /// </summary>
    /// <param name="bucketName">文件桶</param>
    /// <param name="objectId">对象存储名称</param>
    /// <param name="stream">对象输出流</param>
    public async Task UploadObject(string bucketName,string objectId, Stream stream)
    {
        
        //上传文件
        var putObjectArgs = new PutObjectArgs()
            .WithBucket(bucketName)
            .WithObject(objectId)
            .WithStreamData(stream)
            .WithObjectSize(-1L);
        
        await _minioClient.PutObjectAsync(putObjectArgs);
    }

    public async Task<string> GetObjectUrl(string objectName, string bucketName)
    {
        var presignedObjectArgs =
            new PresignedGetObjectArgs()
                .WithBucket(bucketName)
                .WithObject(objectName)
                .WithExpiry(3600);//过期时间
        var result = await _minioClient.PresignedGetObjectAsync(presignedObjectArgs).ConfigureAwait(false);
        return result;
    }

    public async Task DeleteObject(string objectName, string bucketName)
    {
        var removeArgs = new RemoveObjectArgs()
            .WithBucket(bucketName)
            .WithObject(objectName);

        _minioClient.RemoveObjectAsync(removeArgs);
    }
    public ObjectStorageService(IMinioClient minioClient)
    {
        _minioClient = minioClient;
    }
}
