using E_commerce_Product_Catalog.Service.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_Product_Catalog.Service.Commands
{
    public class AddProductCommand : AbstractValidator <Product>
    {
        public AddProductCommand(string name, decimal price, int quantity)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Must(o => string.IsNullOrWhiteSpace(name) || name.Length < 1 || name.Length > 100);

            RuleFor(x => x.Price)
                .NotEmpty()
                .WithMessage("Price cannot be empty.")
                .GreaterThan(0)
                .WithMessage("Price must be greater than 0.");


            RuleFor(x => x.Quantity)
                .NotEmpty()
                .WithMessage("Quantity cannot be empty.")
                .GreaterThan(0)
                .WithMessage("Quantity must be greater than 0.");

        }
    }
}
