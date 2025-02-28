using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace E_commerc.Extenstion;

public static class JwtConfigurationExtensions
{
    public static IServiceCollection AddJwtBearerAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,

                    ValidIssuer = configuration.GetJwtIssuer(),
                    ValidAudience = configuration.GetJwtAudience(),
                    IssuerSigningKey = configuration.GetIssuerSigningKey(),

                    ClockSkew = TimeSpan.Zero
                };
            });

        return services;
    }

    public static string GetJwtIssuer(this IConfiguration configuration) =>
        configuration.GetValueOrThrow("Authentication:Issuer");

    public static string GetJwtAudience(this IConfiguration configuration) =>
        configuration.GetValueOrThrow("Authentication:Audience");

    public static string GetJwtSecret(this IConfiguration configuration) =>
        configuration.GetValueOrThrow("Authentication:SecretKey");

    public static SecurityKey GetIssuerSigningKey(this IConfiguration configuration) =>
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetJwtSecret()));

    public static string GetValueOrThrow(this IConfiguration configuration, string key) =>
        configuration[key] ?? throw new InvalidOperationException($"{key} is missing in configuration.");
}