using E_commerce_Product_Catalog.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_Product_Catalog.Service.Services.Abstractions
{
    public interface IUserRepository
    {
        User GetUserById(Guid id);
        IEnumerable<User> GetAllUsers();
        void AddUser(User user);
        bool IsEmailUnique(string email);
    }
}
