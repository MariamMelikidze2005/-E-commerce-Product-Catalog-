using E_commerce_Product_Catalog.Service.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_Product_Catalog.Service.Commands
{
    public class UpdateCategoryCommand : AbstractValidator<Category>
    {
        //public UpdateCategoryCommand(newCategoryName)
        //{
        //    RuleFor(x => x.CategoryName)
        //   .NotEmpty()
        //   .Must(o => string.IsNullOrWhiteSpace(newCategoryName) || newCategoryName.Length > 1 || newCategoryName.Length < 100);

            
        //}
    }
}
