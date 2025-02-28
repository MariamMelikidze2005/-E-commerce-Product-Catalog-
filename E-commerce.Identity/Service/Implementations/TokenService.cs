using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using E_commerce.Identity.Exceptions;
using E_commerce.Identity.Models;
using E_commerce.Identity.Service.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace E_commerce.Identity.Service.Implementations;

public sealed class TokenService : ITokenService
{
    private readonly TokenServiceOptions _options;
    private readonly ITokenRepository _tokenRepository;

    public TokenService(IOptions<TokenServiceOptions> options, ITokenRepository tokenRepository)
    {
        _options = options.Value;
        _tokenRepository = tokenRepository;
    }


    public string GenerateAccessTokenFor(ApplicationUser user)
    {
        var signInCredentials = new SigningCredentials(_options.GetIssuerSigningKey(), SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new("sub", user.Id),
            new("username", user.UserName!)
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

    public async Task<string> GenerateRefreshTokenAsync(ApplicationUser user)
    {
        var refreshToken = RefreshToken.CreateNewToken(user.Id);
        await _tokenRepository.AddRefreshTokenAsync(refreshToken);
        return refreshToken.Value;
    }

    public async Task<string> RefreshTokenAsync(string token)
    {
        var refreshToken = await _tokenRepository.GetRefreshTokenAsync(token);

        if (refreshToken is null)
        {
            throw new AuthenticationException("Invalid refresh token");
        }

        if (refreshToken.ExipiresAt <= DateTime.Now)
        {
            throw new AuthenticationException("Refresh token has expired");
        }

        refreshToken.Update();
        await _tokenRepository.UpdateAsync(refreshToken);

        return refreshToken.Value;
        
}
}

