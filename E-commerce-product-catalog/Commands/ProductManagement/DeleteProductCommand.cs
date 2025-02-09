using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_commerce_product_catalog.Abstraction;

namespace E_commerce_product_Catalog.Domain.Commands
{
    public class DeleteProductCommand : ICommand
    {
        public int ProductId { get; set; }

        public void Validate()
        {
            if (ProductId <= 0)
            {
                throw new ArgumentException("Invalid Product ID.");
            }
        }
    }
}
