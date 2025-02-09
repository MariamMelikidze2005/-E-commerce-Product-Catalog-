
using E_commerce_Product_Catalog.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_commerce_product_catalog.Abstraction;
using E_commerce_product_catalog.Models;

namespace E_commerce_Product_Catalog.Service.Services.Abstractions
{
    public class CartRepository : ICartRepository
    {
        private readonly List<Cart> _carts = new();

        public async Task<Cart?> GetCartByUserIdAsync(Guid userId)
        {
            return await Task.FromResult(_carts.FirstOrDefault(c => c.UserId == userId));
        }

        Task<List<Cart>> ICartRepository.GetAllCartsAsync()
        {
            return GetAllCartsAsync();
        }

        Task<bool> ICartRepository.ContainsCartAsync(Cart cart)
        {
            throw new NotImplementedException();
        }

        Task ICartRepository.UpdateCartAsync(Cart cart)
        {
            throw new NotImplementedException();
        }

        Task ICartRepository. AddCartAsync(Cart cart)
        {
            throw new NotImplementedException();
        }

        public async Task AddCartAsync(Cart cart)
        {
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

        async Task ICartRepository.RemoveCartAsync(Cart cart)
        {
            await Task.Run(() => _carts.Remove(cart));
        }

        Task<Cart?> ICartRepository.GetCartByUserIdAsync(Guid userId)
        {
            return GetCartByUserIdAsync(userId);
        }

        public Task RemoveCartAsync(Cart cart)
        {
            throw new NotImplementedException();
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
