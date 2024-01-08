using Imagist_Library.Apis.UserApi;
using Imagist_Library.Apis;
using Imagist_Library.Apis.UserApi.Login;
using Imagist_Library.Apis.UserApi.Register;

namespace Imagist_Backend.Service;

public interface IAccountService
{
    public Task<Api<RegisterResponse>> Register(RegisterRequest request, IFormFile userProfile);
    public Api<LoginResponse> Login(LoginRequest request);
    
}