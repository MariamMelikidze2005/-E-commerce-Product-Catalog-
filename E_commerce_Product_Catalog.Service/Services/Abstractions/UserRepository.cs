using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_commerce_Product_Catalog.Service.Models;
using E_commerce_Product_Catalog.Service.Services.Abstractions;

namespace E_commerce_Product_Catalog.Service.Services.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>();

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await Task.FromResult(_users.FirstOrDefault(user => user.Id == id));
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await Task.FromResult(_users);
        }

        public async Task AddUserAsync(User user)
        {
            await Task.Run(() => _users.Add(user));
        }

        public async Task<bool> IsEmailUniqueAsync(string email)
        {
            return await Task.FromResult(!_users.Any(user => user.Email == email));
        }
    }
}
