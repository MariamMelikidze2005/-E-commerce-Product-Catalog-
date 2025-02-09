//using E_commerce_Product_Catalog.Service.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_commerce_product_catalog.Models;

namespace E_commerce_Product_Catalog.Service.Commands
{
    public class AddProductCommand : AbstractValidator<Product>
    {
        public AddProductCommand()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Product name cannot be empty.")
                .MaximumLength(100).WithMessage("Product name cannot exceed 100 characters.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");

            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(0).WithMessage("Quantity must be 0 or greater.");

            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("CategoryId cannot be empty.");

            RuleFor(x => x.OwnerId)
                .NotEmpty().WithMessage("OwnerId cannot be empty.");
        }
    }
}
