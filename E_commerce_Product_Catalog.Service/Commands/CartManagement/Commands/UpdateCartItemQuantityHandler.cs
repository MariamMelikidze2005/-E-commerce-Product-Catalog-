﻿using E_commerce_Product_Catalog.Service.Abstractions;
using MediatR;
using ICartRepository = E_commerce_Product_Catalog.Service.Abstractions.ICartRepository;

<<<<<<<< HEAD:E_commerce_Product_Catalog.Service/Commands/CartManagement/Commands/UpdateCartItemQuantityHandler.cs
namespace E_commerce_Product_Catalog.Service.Commands.CartManagement.Commands
========
namespace E_commerce_Product_Catalog.Service.Commands.CartManagement.update
>>>>>>>> 437baf656f4258360a9208bac00fc648ee20f9d4:E_commerce_Product_Catalog.Service/Commands/CartManagement/update/UpdateCartItemQuantityHandler.cs
{
    public class UpdateCartItemQuantityHandler : IRequestHandler<UpdateCartItemQuantityCommand>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;

        public UpdateCartItemQuantityHandler(ICartRepository cartRepository, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }

        public async Task Handle(UpdateCartItemQuantityCommand request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetCartByUserIdAsync(request.UserId);
            if (cart == null) throw new InvalidOperationException("Cart not found for this user.");

            var item = cart.Items.FirstOrDefault(i => i.ProductId == request.ProductId);
            if (item == null) throw new InvalidOperationException("Product not found in cart.");

            var product = await _productRepository.GetProductByIdAsync(request.ProductId);
            if (product == null) throw new InvalidOperationException("Product not found.");

            if (request.NewQuantity == 0)
            {
                cart.Items.Remove(item);
            }
            else
            {
                item.Quantity = request.NewQuantity;
            }

            if (cart.Items.Count == 0)
                await _cartRepository.RemoveCartAsync(cart.Id);
            else
                await _cartRepository.UpdateCartAsync(cart);
        }
    }
}