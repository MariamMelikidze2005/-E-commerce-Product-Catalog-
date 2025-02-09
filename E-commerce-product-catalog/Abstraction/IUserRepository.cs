
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using E_commerce_product_catalog.Models;

namespace E_commerce_product_catalog.Abstraction
{
    public interface IUserRepository
    {
        Task<User?> GetUserByIdAsync(Guid id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task AddUserAsync(User user);
        Task<bool> IsEmailUniqueAsync(string email);
    }
}
