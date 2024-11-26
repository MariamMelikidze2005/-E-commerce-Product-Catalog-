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
        private List<User> _users = new List<User>();

        public Guid Id { get; private set; }

        public User RegisterUser(string name, string email, string password)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length < 1 || name.Length > 100)
                //throw new InvalidNameException();

                if (string.IsNullOrWhiteSpace(password) || password.Length < 8 || password.Length > 16)
                    //throw new InvalidPasswordException();


                    if (string.IsNullOrWhiteSpace(email) || email.Length > 100 || !IsValidEmail(email))
                        //throw new InvalidEmailFormatException(email);
                        if (_users.Any(u => u.Email == email)) ;
            //throw new UserAlreadyExistsException(email);


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
        private bool IsValidEmail(string email)
        {
            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }


        public User GetUserById(Guid id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
            //throw new UserNotFoundException(Id);
        }
    }
}
