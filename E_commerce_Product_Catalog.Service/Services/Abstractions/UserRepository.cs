using E_commerce_product_catalog.Abstraction;
using E_commerce_product_catalog.Models;

namespace E_commerce_Product_Catalog.Service.Services.Abstractions
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>();

        public Task<User?> GetUserByIdAsync(Guid id) =>
            Task.FromResult(_users.FirstOrDefault(user => user.Id == id));

        public Task<IEnumerable<User>> GetAllUsersAsync() =>
            Task.FromResult<IEnumerable<User>>(_users);

        public Task AddUserAsync(User user) =>
            Task.Run(() => _users.Add(user));

        public Task<bool> IsEmailUniqueAsync(string email) =>
            Task.FromResult(!_users.Any(user => user.Email == email));
    }
}