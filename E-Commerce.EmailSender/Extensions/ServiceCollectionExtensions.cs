using E_Commerce.EmailSender.Abstractions.Models;
using E_Commerce.EmailSender.Abstractions.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using E_Commerce.EmailSender.Services;
namespace E_Commerce.EmailSender.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMailSender(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IEmailSender, EmailSenderi>()
            .Configure<EmailSenderOptions>(configuration.GetSection(EmailSenderOptions.Key));

        return services;
    }
}