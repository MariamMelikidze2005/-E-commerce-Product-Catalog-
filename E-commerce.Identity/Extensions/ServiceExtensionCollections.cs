using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_commerce.Identity.Models;
using E_commerce.Identity.Service.Abstractions;
using E_commerce.Identity.Service.Implementations;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace E_commerce.Identity.Extensions
{
    public static class ServiceExtensionCollections
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services,
            IConfiguration configuration) => services
            .AddScoped<ITokenService, TokenService>()
            .Configure<TokenServiceOptions>(configuration.GetSection(TokenServiceOptions.Key));

    }
}
