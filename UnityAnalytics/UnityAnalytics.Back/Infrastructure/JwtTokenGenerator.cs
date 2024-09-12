using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using UnityAnalytics.Back.Core.Application.Dto;

namespace UnityAnalytics.Back.Infrastructure;

public class JwtTokenGenerator
{
    public static TokenResponseDto GenerateToken(UserDto userDto)
    {
        var claims = new List<Claim>();

        if (!string.IsNullOrEmpty(userDto.Role))
        {
            claims.Add(new Claim(ClaimTypes.Role, userDto.Role));
        }

        claims.Add(new Claim(ClaimTypes.NameIdentifier, userDto.Id.ToString()));

        if (!string.IsNullOrEmpty(userDto.Username))
        {
            claims.Add(new Claim("UserName", userDto.Username));
        }

        var expireDate = DateTime.UtcNow.AddDays(JwtTokenDefaults.Expire);
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));
        var credentials = new SigningCredentials(key: securityKey, algorithm: SecurityAlgorithms.HmacSha256);
        var handler = new JwtSecurityTokenHandler();
        var jwtSecurityToken = new JwtSecurityToken(issuer: JwtTokenDefaults.ValidIssuer,
            audience: JwtTokenDefaults.ValidAudience, claims: claims, notBefore: DateTime.UtcNow,
            expires: expireDate, signingCredentials: credentials);
        
        return new TokenResponseDto(handler.WriteToken(jwtSecurityToken), expireDate);
    }
}