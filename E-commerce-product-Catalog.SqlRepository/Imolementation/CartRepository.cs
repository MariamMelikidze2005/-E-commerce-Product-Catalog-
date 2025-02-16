using E_commerce_product_catalog.Abstraction;
using E_commerce_product_catalog.Models;
using E_commerce_product_Catalog.SqlRepository.Database;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_product_Catalog.SqlRepository.Imolementation
{
    internal sealed class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CartRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Cart?> GetCartByUserIdAsync(Guid userId)
        {
            return await _dbContext.Carts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public async Task RemoveCartAsync(Cart cart)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Cart>> GetAllCartsAsync()
        {
            return await _dbContext.Carts
                .Include(c => c.Items)
                .ToListAsync();
        }

        public async Task<bool> ContainsCartAsync(Cart cart)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ContainsCartAsync(Guid userId)
        {
            return await _dbContext.Carts.AnyAsync(c => c.UserId == userId);
        }

        public async Task AddCartAsync(Cart cart)
        {
            await _dbContext.Carts.AddAsync(cart);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCartAsync(Cart cart)
        {
            var existingCart = await _dbContext.Carts.FindAsync(cart.Id);
            if (existingCart != null)
            {
                existingCart.Items = cart.Items;
                _dbContext.Carts.Update(existingCart);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task RemoveCartAsync(Guid userId)
        {
            var cart = await _dbContext.Carts.FirstOrDefaultAsync(c => c.UserId == userId);
            if (cart != null)
            {
                _dbContext.Carts.Remove(cart);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
