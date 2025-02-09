using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_commerce_product_catalog.Abstraction;

namespace E_commerce_product_Catalog.Domain.Commands
{
    public class AddProductCommand : ICommand
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int OwnerId { get; set; }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new ArgumentException("Product name cannot be empty.");
            }
            if (Price <= 0)
            {
                throw new ArgumentException("Price must be greater than zero.");
            }
            if (CategoryId <= 0 || OwnerId <= 0)
            {
                throw new ArgumentException("Invalid Category or Owner ID.");
            }
        }
    }
}
