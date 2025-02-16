using E_commerce_product_catalog.Abstractions;
using E_commerce_Product_Catalog.Service.Services.Abstractions;
using E_commerce_product_Catalog.SqlRepository.UnitofWork;
using Microsoft.Extensions.DependencyInjection;

namespace E_commerce_product_catalog.Extention
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSqlRepositories(this IServiceCollection services) => services
            .AddScoped<IUnitOfWork, UnitOfWork>()
            //.AddScoped<ICartRepository, CartRepository>()
            //.AddScoped<ITokenRepository, TokenRepository>()
            .AddScoped<ICategoryRepository, CategoryRepository>() 
            .AddScoped<IOrderRepository, OrderRepository>()
            .AddScoped<IProductRepository, ProductRepository>()
            .AddScoped<IUserRepository, UserRepository>();
    }
}