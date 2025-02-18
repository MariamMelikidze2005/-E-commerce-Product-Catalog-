using E_commerce.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using E_commerce.Identity.Services.Abstractions;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace E_commerce.Identity.Services.Implementations
{
    public sealed class TokenService : ITokenService
    {
       private readonly TokenServiceOptions _options;

       public TokenService(TokenServiceOptions options)
       {
           _options = options;
       }


       public string GenerateAccessToken(ApplicationUser user)
       {
           var signInCredentials = new SigningCredentials(_options.GetIssuerSigningKey(), SecurityAlgorithms.HmacSha256);

           var claims = new List<Claim>
           {
               new ("sub", user.Id),
               new ("preferred_username", user.UserName!)
           };

           var jwtSecurityToken = new JwtSecurityToken(
               issuer: _options.Issuer,
               audience: _options.Audience,
               claims,
               notBefore: DateTime.UtcNow,
               expires: DateTime.UtcNow.AddMinutes(1),
               signInCredentials);

           return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
       }
    }
}
