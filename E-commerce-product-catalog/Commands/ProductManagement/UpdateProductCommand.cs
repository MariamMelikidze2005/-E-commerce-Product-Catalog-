using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_commerce_product_catalog.Abstraction;

namespace E_commerce_product_Catalog.Domain.Commands
{
    public class UpdateProductCommand : ICommand
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public void Validate()
        {
            if (ProductId <= 0)
            {
                throw new ArgumentException("Invalid Product ID.");
            }
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new ArgumentException("Product name cannot be empty.");
            }
            if (Price <= 0)
            {
                throw new ArgumentException("Price must be greater than zero.");
            }
        }
    }
}
