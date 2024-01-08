using Imagist_Backend.Service;
using Imagist_Library.Apis.UserApi;
using Imagist_Library.Apis;
using Imagist_Library.Apis.UserApi.Login;
using Imagist_Library.Apis.UserApi.Register;
using Imagist_Library.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Imagist_Backend.ApiController;

[ApiController]
[Route("[Controller]/")]
public class UserController : Controller
{
    private readonly IAccountService _accountService;

    [HttpPost("register")]
    public Task<Api<RegisterResponse>> Register(IFormFile userProfile,string username,string email,string password)
    {
        var r = new RegisterRequest()
        {
            UserName = username,
            Email = email,
            Password = password
        };
        return _accountService.Register(r,userProfile);
    }
    
    [HttpPost("login")]
    public Api<LoginResponse> Login([FromBody]LoginRequest request)
    {
        return _accountService.Login(request);
    }
    [HttpGet("auth"),Authorize]
    public Api<string> AuthTest()
    {
        string name = this.GetUserName();
        return Api<string>.Success("成功", name);
    }

    public UserController(IAccountService accountService)
    {
        _accountService = accountService;
    }
}