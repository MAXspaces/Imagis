using Flurl.Http;
using Imagist_Library.Apis;
using Imagist_Library.Apis.PhotoApi;
using Imagist_Library.Connectivity.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Imagist_Library.Connectivity.Photo;

public class PhotoClient
{
    public string _baseUrl { get; set; }
    private readonly AuthenticationManager _authentication;

    public PhotoClient(IConfiguration configuration, AuthenticationManager authentication)
    {
        _baseUrl = configuration.GetSection("App:BaseUrl").Value!;
        _authentication = authentication;
    }

    public async Task<Api<long>> UploadPhoto(long albumId, string path)
    {
        var url = _baseUrl + "/Photo";
        var token = _authentication.JwtToken;
        var response =
            url
                .WithOAuthBearerToken(token)
                .AppendQueryParam("albumId", albumId.ToString())
                .PostMultipartAsync(mp => mp
                    .AddFile("file", path));
        return await response.Result.GetJsonAsync<Api<long>>();
    }

    public Api<object> DeletePhoto(long photoId)
    {
        var url = _baseUrl + "/Photo";
        var token = _authentication.JwtToken;
        var response =
            url
                .WithOAuthBearerToken(token)
                .AppendQueryParam("photoId", photoId)
                .DeleteAsync();
        return response.Result.GetJsonAsync<Api<object>>().Result;
    }

    public Api<List<PhotoDto>> GetAllPhotos()
    {
        var url = _baseUrl + "/Photo/all";
        var token = _authentication.JwtToken;
        var response =
            url
                .WithOAuthBearerToken(token)
                .GetJsonAsync<Api<List<PhotoDto>>>();
        return response.Result;
    }

    public  Api<List<PhotoDto>> GetDeletedPhotos()
    {
        var url = _baseUrl + "/Photo/deleted";
        var token = _authentication.JwtToken;
        var response =
            url
                .WithOAuthBearerToken(token)
                .GetJsonAsync<Api<List<PhotoDto>>>();
        return response.Result;
    }

    public Api<object> PermanentDeletePhoto(long photoId)
    {
        var url = _baseUrl + "/Photo/permanent";
        var token = _authentication.JwtToken;
        var response =
            url
                .WithOAuthBearerToken(token)
                .AppendQueryParam("photoId", photoId)
                .DeleteAsync();
        return response.Result.GetJsonAsync<Api<object>>().Result;
    }
    public Api<object> RestorePhoto(long photoId)
    {
        var url = _baseUrl + "/Photo/restore";
        var token = _authentication.JwtToken;
        var response =
            url
            .WithOAuthBearerToken(token)
            .AppendQueryParam("photoId", photoId)
            .PostAsync();
        return response.ReceiveJson<Api<object>>().Result;
    }
}