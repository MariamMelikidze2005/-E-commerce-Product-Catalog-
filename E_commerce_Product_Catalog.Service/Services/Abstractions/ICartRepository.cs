using E_commerce_Product_Catalog.Service.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_commerce_Product_Catalog.Service.Services.Abstractions
{
    public interface ICartRepository
    {
        Task<Cart> GetCartByUserIdAsync(Guid userId);
        Task AddCartAsync(Cart cart);
        Task UpdateCartAsync(Cart cart);
        Task RemoveCartAsync(Cart cart);
        Task<List<Cart>> GetAllCartsAsync();
        Task<bool> ContainsCartAsync(Cart cart);  // Make this asynchronous
    }

}
