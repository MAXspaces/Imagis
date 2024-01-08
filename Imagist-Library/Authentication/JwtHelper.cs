using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Imagist_Library.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Imagist_Library.Authentication;

public class JwtHelper
{
    private readonly IConfiguration _configuration;

    public JwtHelper(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string CreateToken(User user)
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
            new Claim(ClaimTypes.Email,user.Email),
            new Claim(ClaimTypes.Name,user.Username)
        };
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("APP:JwtSecret").Value!));
        var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        var jwtToken = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddHours(2.0),
            signingCredentials: credentials);
        var jwt = new JwtSecurityTokenHandler().WriteToken(jwtToken);

        return jwt;

    }
    
}
