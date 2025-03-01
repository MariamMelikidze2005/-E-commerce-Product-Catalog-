﻿using E_commerce_Product_Catalog.Service.Abstractions;
using E_commerce_product_Catalog.SqlRepository.Imolementation;
using E_commerce_product_Catalog.SqlRepository.UnitofWork;
using E_commerce.Identity.Service.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace E_commerce_product_Catalog.SqlRepository.Extention
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSqlRepositories(this IServiceCollection services) => services
            .AddScoped<IUnitOfWork, UnitOfWork>()
            .AddScoped<ICartRepository, CartRepository>()
            .AddScoped<ITokenRepository, TokenRepository>()
            .AddScoped<ICategoryRepository, CategoryRepository>() 
            .AddScoped<IOrderRepository, OrderRepository>()
            .AddScoped<IProductRepository, ProductRepository>()
            .AddScoped<IUserRepository, UserRepository>();
    }
}