using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace MyBlog.Api.Utils;

public static class AuthenticateToken
{
    public static string GenerateJwtToken(string username)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("DkDslmwwPYCdGqscpuHxUnPRS9QfpaiLqzPN0DOlkzE="));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
             new Claim(JwtRegisteredClaimNames.Sub, username),
             new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
         };

        var token = new JwtSecurityToken(
            issuer: "https://localhost:7294",
            audience: "https://localhost:7179",
            claims: claims,
            expires: DateTime.Now.AddMinutes(60),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}