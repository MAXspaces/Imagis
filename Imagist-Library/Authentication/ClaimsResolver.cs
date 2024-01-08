using System.Security.Claims;
using Imagist_Library.Model;
using Microsoft.AspNetCore.Mvc;
namespace Imagist_Library.Authentication;

public static class ClaimsResolver
{
    public static long GetUserId(this Controller controller)
    {
        var claim = controller.User.Claims.FirstOrDefault(claim => claim.Type.Equals(ClaimTypes.NameIdentifier));
        var id = long.Parse(claim!.Value);
        return id;
    }

    public static string GetUserName(this Controller controller)
    {
        var claim = controller.User.Claims.FirstOrDefault(claim => claim.Type.Equals(ClaimTypes.Name));
        return claim!.Value;
    }
    public static string GetUserEmail(this Controller controller)
    {
        var claim = controller.User.Claims.FirstOrDefault(claim => claim.Type.Equals(ClaimTypes.Email));
        return claim!.Value;
    }

    public static User GetUser(this Controller controller)
    {
        return new User()
        {
            UserId = controller.GetUserId(),
            Username = controller.GetUserName(),
            Email = controller.GetUserEmail()
        };
    }
}
