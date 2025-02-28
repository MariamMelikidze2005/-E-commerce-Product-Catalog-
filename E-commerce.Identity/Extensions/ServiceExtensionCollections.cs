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
        public static IdentityBuilder AddIdentityServices(this IServiceCollection services, IConfiguration configuration, Action<IdentityOptions>? setupAction = null) => services
            .AddScoped<ITokenService, TokenService>()
            .Configure<TokenServiceOptions>(configuration.GetSection(TokenServiceOptions.Key))
            .AddScoped<IIdentityService, IdentityService>()
            .AddIdentity<ApplicationUser, ApplicationRole>(setupAction ?? DefaultSetupAction)
            .AddTokenProvider<PasswordTokenProvider<ApplicationUser>>("ResetPassword")
            .AddDefaultTokenProviders();
        private static void DefaultSetupAction(IdentityOptions options)
        {
            options.Password = new PasswordOptions
            {
                RequireDigit = true,
                RequireLowercase = true,
                RequireNonAlphanumeric = true,
                RequireUppercase = true,
                RequiredLength = 8,
                RequiredUniqueChars = 3,
            };

            options.Lockout = new LockoutOptions { AllowedForNewUsers = true, DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1), MaxFailedAccessAttempts = 3, };

            options.SignIn.RequireConfirmedAccount = true;
            options.SignIn.RequireConfirmedEmail = true;
        }
    }
}
