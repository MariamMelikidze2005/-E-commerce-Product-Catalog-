//using FluentValidation;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml.Linq;
//using E_commerce_Product_Catalog.Service.validation;
//using System.Security.Cryptography.X509Certificates;
//using E_commerce_product_catalog.Models;

//namespace E_commerce_Product_Catalog.Service.fluentvalidation
//{
//    public class UserRegristrationcommand : AbstractValidator<User>
//    {
//        public UserRegristrationcommand()
//        {
//            var emailValidator = new EmailValidator();


//            RuleFor(x => x.Name)
//             .NotEmpty().WithMessage("Category name cannot be empty.")
//             .Must(name => name.Length > 1 || name.Length < 100);

//            RuleFor(x => x.Password)
//                    .NotEmpty()
//                    .Must(password => string.IsNullOrWhiteSpace(password) || password.Length < 8 || password.Length > 16);

//            RuleFor(x => x.Email)
//                .NotEmpty()
//                .Must(email => string.IsNullOrWhiteSpace(email) || email.Length > 100 || !emailValidator.IsValidEmail(email));

//        }

//    }
//}
