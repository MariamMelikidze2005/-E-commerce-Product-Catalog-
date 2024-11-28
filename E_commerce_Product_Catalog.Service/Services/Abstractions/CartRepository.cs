using E_commerce_Product_Catalog.Service.Models;
using E_commerce_Product_Catalog.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce_Product_Catalog.Service.Services.Abstractions
{
    public class CartRepository : ICartRepository
    {
        private readonly List<Cart> _carts = new();

        public async Task<Cart> GetCartByUserIdAsync(Guid userId)
        {
            // Simulating async work (e.g., querying a database)
            return await Task.FromResult(_carts.FirstOrDefault(c => c.UserId == userId));
        }

        public async Task AddCartAsync(Cart cart)
        {
            // Simulating async work (e.g., inserting a record in a database)
            await Task.Run(() => _carts.Add(cart));
        }

        public async Task UpdateCartAsync(Cart cart)
        {
            await Task.Run(() =>
            {
                var existingCart = _carts.FirstOrDefault(c => c.UserId == cart.UserId);
                if (existingCart != null)
                {
                    existingCart.Items = cart.Items;
                }
            });
        }

        public async Task RemoveCartAsync(Cart cart)
        {
            await Task.Run(() => _carts.Remove(cart));
        }

        public async Task<List<Cart>> GetAllCartsAsync()
        {
            return await Task.FromResult(_carts);
        }

        public async Task<bool> ContainsCartAsync(Cart cart)
        {
            return await Task.FromResult(_carts.Any(c => c.UserId == cart.UserId));
        }
    }

}
