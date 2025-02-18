using E_commerce.Identity.Extension;

namespace E_commerc.Extension
{
    public static class WebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder AddJwtConfiguration(this WebApplicationBuilder builder)
        {
            return builder.Services.AddJwtBearerAuthentication(builder.Configuration);
        }
        public static WebApplicationBuilder AddAccessToken(this WebApplicationBuilder builder)
        {
            return builder.Services.AddJwtTokenServices(builder.Configuration);
        }
    }
}
