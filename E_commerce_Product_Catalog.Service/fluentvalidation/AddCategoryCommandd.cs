//using FluentValidation;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml.Linq;
//using E_commerce_product_catalog.Models;

//namespace E_commerce_Product_Catalog.Service.fluentvalidation
//{
//    public class AddCategoryCommandd : AbstractValidator<Category>
//    {
//        public AddCategoryCommandd()
//        {
//            RuleFor(x => x.CategoryName)
//                .NotEmpty().WithMessage("Category name cannot be empty.")
//                .Length(1, 100).WithMessage("Category name must be between 1 and 100 characters.");
//        }
//    }
//}
