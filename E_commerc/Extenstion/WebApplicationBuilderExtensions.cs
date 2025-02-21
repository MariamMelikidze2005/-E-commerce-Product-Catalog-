using E_commerce.Identity.Extensions;

namespace E_commerc.Extenstion
{
    public static class WebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder AddJwtAuthentication(this WebApplicationBuilder builder)
        {
            builder.Services.AddJwtBearerAuthentication(builder.Configuration);
            return builder;
        }

        public static WebApplicationBuilder AddTokens(this WebApplicationBuilder builder)
        {
            builder.Services.AddIdentityServices(builder.Configuration);
            return builder;
        }
    }
}
