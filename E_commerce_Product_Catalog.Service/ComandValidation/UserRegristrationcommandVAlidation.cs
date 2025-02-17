using E_commerce_product_catalog.Models;
using E_commerce_Product_Catalog.Service.validation;
using FluentValidation;

namespace E_commerce_Product_Catalog.Service.ComandValidation
{
    public class UserRegristrationcommandVAlidation : AbstractValidator<User>
    {
        public UserRegristrationcommandVAlidation()
        {
            var emailValidator = new EmailValidator();


            RuleFor(x => x.Name)
             .NotEmpty().WithMessage("Category name cannot be empty.")
             .Must(name => name.Length > 1 || name.Length < 100);

            RuleFor(x => x.Password)
                    .NotEmpty()
                    .Must(password => string.IsNullOrWhiteSpace(password) || password.Length < 8 || password.Length > 16);

            RuleFor(x => x.Email)
                .NotEmpty()
                .Must(email => string.IsNullOrWhiteSpace(email) || email.Length > 100 || !emailValidator.IsValidEmail(email));

        }

    }
}
