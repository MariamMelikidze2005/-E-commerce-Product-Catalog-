using E_commerce_Product_Catalog.Service.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace E_commerce_Product_Catalog.Service.Commands
{
    public class AddCategoryCommand : AbstractValidator<Category>
    {
        public AddCategoryCommand(string categoryName)
        {
            RuleFor(x => x.CategoryName)
                .NotEmpty().WithMessage("Category name cannot be empty.")
                .Length(1, 100).WithMessage("Category name must be between 1 and 100 characters.");
        }
    }
}
