﻿using FluentValidation;
using System;
using E_commerce_product_catalog.Models;

namespace E_commerce_Product_Catalog.Service.Commands
{
    public class UpdateCartItemQuantityCommand : AbstractValidator<CartItem>
    {
        public UpdateCartItemQuantityCommand()
        {
            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.");

            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("ProductId cannot be empty.");
        }
    }
}
