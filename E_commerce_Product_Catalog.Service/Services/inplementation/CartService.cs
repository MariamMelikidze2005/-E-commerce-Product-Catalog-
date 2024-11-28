using E_commerce_Product_Catalog.Service.Commands;
using E_commerce_Product_Catalog.Service.Exceptions;
using E_commerce_Product_Catalog.Service.Models;
using E_commerce_Product_Catalog.Service.Services.Abstractions;
using E_commerce_Product_Catalog.Service.Services.Abstractions.E_commerce_Product_Catalog.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce_Product_Catalog.Service.Services.Implementation
{
    public class CartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly UpdateCartItemQuantityCommand _updateCartItemQuantityCommand;

        public CartService(ICartRepository cartRepository, IProductRepository productRepository, UpdateCartItemQuantityCommand updateCartItemQuantityCommand)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _updateCartItemQuantityCommand = updateCartItemQuantityCommand;
        }


        public async Task AddToCartAsync(Guid userId, Guid productId, int quantity)
        {
            if (quantity <= 0)
                throw new InvalidQuantitiyOfCartItemExeption(productId);

            var product = await GetProductByIdAsync(productId);
            var cart = await _cartRepository.GetCartByUserIdAsync(userId) ?? new Cart { UserId = userId };

            var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (item == null)
            {
                cart.Items.Add(new CartItem { ProductId = productId, Quantity = quantity });
            }
            else
            {
                item.Quantity += quantity;
            }

            if (!await _cartRepository.ContainsCartAsync(cart))
                await _cartRepository.AddCartAsync(cart);
        }

        public async Task UpdateProductQuantityAsync(Guid userId, Guid productId, int newQuantity)
        {
            var cartItem = new CartItem { ProductId = productId, Quantity = newQuantity };

            var validationResult = _updateCartItemQuantityCommand.Validate(cartItem);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ArgumentException($"Validation failed: {errors}");
            }

            var cart = await _cartRepository.GetCartByUserIdAsync(userId);
            if (cart == null) throw new InvalidOperationException("Cart not found for this user.");

            var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (item == null) throw new InvalidOperationException("Product not found in cart.");

            var product = await GetProductByIdAsync(productId);
            if (product.Quantity == 0 || newQuantity == 0)
            {
                cart.Items.Remove(item);
            }
            else if (product.Quantity >= newQuantity) // Correct comparison to prevent exceeding stock
            {
                item.Quantity = newQuantity;
            }

            if (cart.Items.Count == 0)
                await _cartRepository.RemoveCartAsync(cart);
            else
                await _cartRepository.UpdateCartAsync(cart);
        }

        public async Task RemoveProductAsync(Guid userId, Guid productId)
        {
            var cart = await _cartRepository.GetCartByUserIdAsync(userId);
            if (cart == null) throw new InvalidOperationException("Cart not found for this user.");

            var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (item == null) throw new InvalidOperationException("Product not found in cart.");

            cart.Items.Remove(item);

            if (cart.Items.Count == 0)
                await _cartRepository.RemoveCartAsync(cart);
            else
                await _cartRepository.UpdateCartAsync(cart); 
        }

        private async Task<Product> GetProductByIdAsync(Guid productId)
        {
            var product = await _productRepository.GetProductByIdAsync(productId);
            if (product == null) throw new InvalidOperationException("Product not found");
            return product;
        }

        public async Task<List<CartItem>> GetCartItemsAsync(Guid userId)
        {
            var cart = await _cartRepository.GetCartByUserIdAsync(userId);
            return cart?.Items ?? new List<CartItem>();
        }
    }
}
