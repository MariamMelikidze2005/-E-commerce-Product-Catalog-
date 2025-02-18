using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;   
using E_commerce.Identity.Models;
using E_commerce.Identity.Services.Abstractions;
using E_commerce.Identity.Services.Implementations;

namespace E_commerce.Identity.Extension
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddJwtTokenServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITokenService, TokenService>()
                .Configure<TokenServiceOptions>(configuration.GetSection(TokenServiceOptions.Key));
            return services;
        }
    }
}
