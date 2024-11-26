using E_commerce_Product_Catalog.Service.Exceptions;
using E_commerce_Product_Catalog.Service.Models;
using E_commerce_Product_Catalog.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace E_commerce_Product_Catalog.Service.Services.inplementation
{
    public class CartService
    {
        private readonly ICartRepository _cartRepository;
        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }


        private List<Cart> _carts = new List<Cart>();
        private List<Product> _products = new List<Product>();

        public void AddToCart(Guid userId, Guid productId, int quantity)
        {
            if (quantity <= 0)
                throw new InvalidQuantitiyOfCartItemExeption(productId);
            var product = GetProductById(productId);
            var cart = _carts.FirstOrDefault(c => c.UserId == userId) ?? new Cart { UserId = userId };

            var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (item == null)
            {
                cart.Items.Add(new CartItem { ProductId = productId, Quantity = quantity });
            }
            else
            {
                item.Quantity += quantity;
            }
            if (!_carts.Contains(cart))
                _carts.Add(cart);
        }

        public void UpdateProductQuantity(Guid userId, Guid productId, int newQuantity)
        {
            if (newQuantity <= 0) throw new InvalidQuantitiyOfCartItemExeption(productId);

            var cart = _carts.FirstOrDefault(c => c.UserId == userId);
            if (cart == null) throw new InvalidOperationException("Cart not found for this user.");

            var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (item == null) throw new InvalidOperationException("Product not found in cart.");

            var product = GetProductById(productId);
            if (product.Quantity == 0 || newQuantity == 0) { cart.Items.Remove(item); }
            else if (product.Quantity > newQuantity) { item.Quantity = product.Quantity; }
            else { item.Quantity = newQuantity; }

            if (cart.Items.Count == 0) { _carts.Remove(cart); }
        }
        public void RemoveProduct(Guid userId, Guid productId)
        {
            var cart = _carts.FirstOrDefault(c => c.UserId == userId);
            if (cart == null) throw new InvalidOperationException("Cart not found for this user.");

            var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (item == null) { throw new InvalidOperationException("Product not found in cart"); }
            cart.Items.Remove(item);

            if (cart.Items.Count == 0) _carts.Remove(cart);
        }

        private Product GetProductById(Guid productId)
        {
            var product = _products.FirstOrDefault(p => p.Id == productId);
            if (product == null) { throw new InvalidOperationException("product not fouund"); }
            return product;
        }



        public List<CartItem> GetCartItems(Guid userId)
        {
            return _carts.FirstOrDefault(c => c.UserId == userId)?.Items ?? new List<CartItem>();
        }


    }
}
