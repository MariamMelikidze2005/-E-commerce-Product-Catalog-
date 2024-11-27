using E_commerce_Product_Catalog.Service.Commands;
using E_commerce_Product_Catalog.Service.Exceptions;
using E_commerce_Product_Catalog.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace E_commerce_Product_Catalog.Service.Services.inplementation
{
    public class UserService
    {
        private readonly List<User> _users = new List<User>();

        public User RegisterUser(string name, string email, string password)
        {
            var userValidator = new UserRegristration(name, password, email);

            var validationResult = userValidator.Validate(new User
            {
                Name = name,
                Email = email,
                Password = password
            });

            if (!validationResult.IsValid)
            {
                var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ArgumentException($"Validation failed: {errors}");
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email,
                Password = password
            };

            _users.Add(user);
            return user;
        }

        public User GetUserById(Guid id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }
    }
}
