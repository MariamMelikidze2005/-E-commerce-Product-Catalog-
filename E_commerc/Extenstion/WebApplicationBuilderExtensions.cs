using E_commerce.Identity.Extensions;
using E_commerce.Identity.Models;
using E_commerce_product_Catalog.SqlRepository.Database;
using System;
using E_commerce_product_Catalog.SqlRepository.Extention;
using E_Commerce.EmailSender.Extensions;

namespace E_commerc.Extenstion
{
    public static class WebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder AddJwtAuthentication(this WebApplicationBuilder builder)
        {
            builder.Services.AddJwtBearerAuthentication(builder.Configuration);
            return builder;
        }

        public static WebApplicationBuilder AddIdentity(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddMailSender(builder.Configuration)
                .AddIdentityServices(builder.Configuration)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            return builder;
        }

        public static WebApplicationBuilder AddSqlRepository(this WebApplicationBuilder builder)
        {
            builder.Services.AddSqlRepositories();
            return builder;
        }

    }
}
