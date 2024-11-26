using E_commerce_Product_Catalog.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_Product_Catalog.Service.Services.Abstractions
{
    public interface ICartRepository
    {
        Cart GetById (Guid id);
        void SaveCartInfo (Cart cart);


    }
}
