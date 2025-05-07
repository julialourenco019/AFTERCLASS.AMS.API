using AFTERCLASS.AMS.API.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MySqlX.XDevAPI;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AFTERCLAS.AMS.API;
using AFTERCLASS.AMS.API;
namespace AFTERCLAS.AMS.API.Application.Auth;


public class TokenAuth
{
    public static object GenerateToken(Teacher teacher)
    {
        var key = Encoding.ASCII.GetBytes(Key.Secret);
        var tokenConfig = new SecurityTokenDescriptor
        {
            Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
            {
                new Claim("TeacherId", teacher.Id.ToString()),
               
            }),
            Expires = DateTime.UtcNow.AddHours(3),
            Issuer = "AFTERCLASS.AMS.API",
            Audience = "AFTERCLASS.AMS.API.Domain",
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenConfig);
        var tokenString = tokenHandler.WriteToken(token);
        return new { token = tokenString };
    }
}

