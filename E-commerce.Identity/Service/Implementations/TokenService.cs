using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using E_commerce.Identity.Models;
using E_commerce.Identity.Service.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace E_commerce.Identity.Service.Implementations;

public sealed class TokenService : ITokenService
{
    private readonly TokenServiceOptions _options;

    public string GenerateAccessTokenFor(ApplicationUser user)
    {
        var signInCredentials = new SigningCredentials(_options.GetIssuerSigningKey(), SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new ("sub", user.Id),
            new ("username", user.UserName!)
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


