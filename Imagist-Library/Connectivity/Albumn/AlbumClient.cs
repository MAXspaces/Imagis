using Flurl.Http;
using Imagist_Library.Apis;
using Imagist_Library.Apis.AlbumApi;
using Imagist_Library.Apis.PhotoApi;
using Imagist_Library.Apis.UserApi.Register;
using Imagist_Library.Connectivity.Account;
using Microsoft.Extensions.Configuration;

namespace Imagist_Library.Connectivity.Albumn;

public class AlbumClient
{
    private readonly IConfiguration _configuration;
    private readonly AuthenticationManager _authentication;
    private readonly string _baseUrl;

    public Api<List<AlbumDto>> GetUserAlbum()
    {
        var url = _baseUrl + "/Album/all";
        var token = _authentication.JwtToken;
        var response = url.WithOAuthBearerToken(token).GetJsonAsync<Api<List<AlbumDto>>>();
        return response.Result;
    }

    public Api<long> CreateAlbum(CreateAlbumRequest request)
    {
        var url = _baseUrl + "/Album";
        var token = _authentication.JwtToken;
        var response = url.WithOAuthBearerToken(token).PutJsonAsync(request);
        return response.Result.GetJsonAsync<Api<long>>().Result;
    }

    public Api<object> DeleteAlbum(long albumId)
    {
        var url = _baseUrl + $"/Album?albumId={albumId}";
        var token = _authentication.JwtToken;
        var response = 
            url
            .WithOAuthBearerToken(token)
            //.AppendQueryParam("album_id",albumId.ToString())
            .DeleteAsync();
        return response.Result.GetJsonAsync<Api<object>>().Result;
    }

    public Api<List<PhotoDto>> GetAlbumPhotos(long albumId)
    {
        var url = _baseUrl + $"/Album/{albumId}/photos";
        var token = _authentication.JwtToken;
        var response = url.WithOAuthBearerToken(token).GetJsonAsync<Api<List<PhotoDto>>>();
        return response.Result;
    }

    public Api<object> EditAlbum(AlbumDto album)
    {
        var url = _baseUrl + "/Album";
        var token = _authentication.JwtToken;
        var response = 
            url
                .WithOAuthBearerToken(token)
                .PostJsonAsync(album);
        return response.Result.GetJsonAsync<Api<object>>().Result;
    }

    public AlbumClient(IConfiguration configuration,AuthenticationManager authentication)
    {
        _baseUrl = configuration.GetSection("App:BaseUrl").Value!;
        _configuration = configuration;
        _authentication = authentication;
    }
}