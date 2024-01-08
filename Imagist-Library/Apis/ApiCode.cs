namespace Imagist_Library.Apis;
/// <summary>
/// 通用Api接口状态码
/// 1->账号相关状态码
/// 2->资源相关状态码
/// </summary>
public enum ApiCode:int
{
    Success = 200,
    LoginFailed = 1001,
    NotLogin = 1002,
    TokenExpired = 1003,
    
    Existed = 2001,
    NotFound =2002,
}