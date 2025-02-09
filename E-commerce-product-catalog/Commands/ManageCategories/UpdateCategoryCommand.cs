using E_commerce_product_catalog.Abstraction;
using E_commerce_product_catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_product_Catalog.Domain.Commands
{
    public class UpdateCategoryCommand : ICommand
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;

        public void Validate()
        {
            if (CategoryId <= 0)
            {
                throw new ArgumentException("Invalid Category ID.");
            }
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new ArgumentException("Category name cannot be empty.");
            }
        }
    }
}

