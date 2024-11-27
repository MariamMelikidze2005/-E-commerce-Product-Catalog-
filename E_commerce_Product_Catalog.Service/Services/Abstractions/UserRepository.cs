using System;
using System.Collections.Generic;
using System.Linq;
using E_commerce_Product_Catalog.Service.Models;
using E_commerce_Product_Catalog.Service.Services.Abstractions;

namespace E_commerce_Product_Catalog.Service.Services.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>();

        public User GetUserById(Guid id)
        {
            return _users.FirstOrDefault(user => user.Id == id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _users;
        }

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public bool IsEmailUnique(string email)
        {
            return !_users.Any(user => user.Email == email);
        }
    }
}
