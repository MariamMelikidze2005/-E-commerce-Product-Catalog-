using E_commerce_product_catalog.Models;
using FluentValidation;

namespace E_commerce_Product_Catalog.Service.ComandValidation
{
    public class AddCategoryCommanddValidation : AbstractValidator<Category>
    {
        public AddCategoryCommanddValidation()
        {
            RuleFor(x => x.CategoryName)
                .NotEmpty().WithMessage("Category name cannot be empty.")
                .Length(1, 100).WithMessage("Category name must be between 1 and 100 characters.");
        }
    }
}
