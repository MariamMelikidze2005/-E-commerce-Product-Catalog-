using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_commerce_product_catalog.Abstraction;

namespace E_commerce_product_Catalog.Domain.Commands
{
    public class UpdateCartItemCommand : ICommand
    {
        public int CartItemId { get; set; }
        public int Quantity { get; set; }

        public void Validate()
        {
            if (CartItemId <= 0)
            {
                throw new ArgumentException("Invalid Cart Item ID.");
            }
            if (Quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than zero.");
            }
        }
    }
}
