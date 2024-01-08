using System.Text.Json;
using Flurl.Http;
using Imagist_Library.Apis;
using Imagist_Library.Apis.UserApi.Login;
using Imagist_Library.Apis.UserApi.Register;
using Microsoft.Extensions.Configuration;

namespace Imagist_Library.Connectivity.HTTP.Account;

public class AccountClient
{
    public string _baseUrl { get; set; } //= "http://localhost:5154";
    
    
    public AccountClient(IConfiguration configuration)
    {
        _baseUrl = configuration.GetSection("App:BaseUrl").Value!;
    }
    //TODO refresh token

    public Api<RegisterResponse> Register(string userName,string email,string password,string profiePath)
    {
        var url = _baseUrl + $"/User/register?username={userName}&email={email}&password={password}";
        var response = url.
            PostMultipartAsync(mp => { 
                mp.AddString("username", userName);
                mp.AddString("email", email);
                mp.AddString("password", password);
                mp.AddFile("userProfile", profiePath);
            });
        return response.Result.GetJsonAsync<Api<RegisterResponse>>().Result;
    }

    public Api<LoginResponse> login(LoginRequest request)
    {
        var url = _baseUrl + "/User/login";
        var response = url.PostJsonAsync(request);
        return response.Result.GetJsonAsync<Api<LoginResponse>>().Result;
    }
}