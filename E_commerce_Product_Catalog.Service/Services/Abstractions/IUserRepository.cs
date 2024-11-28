using E_commerce_Product_Catalog.Service.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_commerce_Product_Catalog.Service.Services.Abstractions
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(Guid id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task AddUserAsync(User user);
        Task<bool> IsEmailUniqueAsync(string email);
    }
}
