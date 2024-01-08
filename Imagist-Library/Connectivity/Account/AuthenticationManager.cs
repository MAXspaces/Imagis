using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Flurl.Http;
using Imagist_Library.Apis;
using Imagist_Library.Apis.UserApi.Login;
using Imagist_Library.Connectivity.HTTP.Account;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Imagist_Library.Connectivity.Account;

public class AuthenticationManager
{
    private readonly AccountClient _accountClient;
    private DateTime TokenExp { get; set; }
    private string _JwtToken;
    public string? JwtToken
    {
        get
        {
            if(DateTime.Now > TokenExp)
            //TODO refresh token
                Console.WriteLine("Token Expired");
            return _JwtToken;
        }
        private set => _JwtToken = value;
    }

    public string? UserId { get; private set; }
    public string? Email { get; private set; }
    public string? Username { get; private set; }
    public string? userProfile { get; private set; }

    public Api<LoginResponse> Login(string email,string password)
    {
        var response = _accountClient.login(new LoginRequest()
        {
            Email = email,
            Password = password
        });
        //解析token
        if (response.IsSuccess)
        {
            ResolveToken(response.Data!.JwtToken);
            JwtToken = response.Data!.JwtToken;
            userProfile = response.Data.profileUrl;
        }
        return response;
    }
    

    private void ResolveToken(string jwt)
    {
        var token = new JwtSecurityTokenHandler().ReadJwtToken(jwt);
        Email = token.Payload.Claims.FirstOrDefault(claim => claim.Type.Equals(ClaimTypes.Email))?.Value;
        Username = token.Payload.Claims.FirstOrDefault(claim => claim.Type.Equals(ClaimTypes.Name))?.Value;
        UserId = token.Payload.Claims.FirstOrDefault(claim => claim.Type.Equals(ClaimTypes.NameIdentifier))?.Value;
        var timeStamp = token.Payload.Claims.FirstOrDefault(claim => claim.Type.Equals("exp"))?.Value;
        TokenExp = DateTimeOffset.FromUnixTimeSeconds(long.Parse(timeStamp)).DateTime.ToLocalTime();
    }

    public AuthenticationManager(AccountClient accountClient)
    {
        _accountClient = accountClient;
    }
}