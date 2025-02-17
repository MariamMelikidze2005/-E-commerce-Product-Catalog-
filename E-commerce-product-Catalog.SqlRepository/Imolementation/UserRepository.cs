using E_commerce_product_catalog.Models;
using E_commerce_Product_Catalog.Service.Abstractions;
using E_commerce_product_Catalog.SqlRepository.Database;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_product_Catalog.SqlRepository.Imolementation
{
    internal sealed class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task AddUserAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> IsEmailUniqueAsync(string email)
        {
            return !await _dbContext.Users.AnyAsync(user => user.Email == email);
        }
    }
}