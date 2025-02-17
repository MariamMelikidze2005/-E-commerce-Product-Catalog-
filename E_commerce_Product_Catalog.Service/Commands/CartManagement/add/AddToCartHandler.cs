using E_commerce_product_catalog.Exceptions;
using E_commerce_product_catalog.Models;
using E_commerce_Product_Catalog.Service.Abstractions;
using MediatR;
using ICartRepository = E_commerce_Product_Catalog.Service.Abstractions.ICartRepository;

<<<<<<<< HEAD:E_commerce_Product_Catalog.Service/Commands/CartManagement/Commands/AddToCartHandler.cs
namespace E_commerce_Product_Catalog.Service.Commands.CartManagement.Commands
========
namespace E_commerce_Product_Catalog.Service.Commands.CartManagement.add
>>>>>>>> 437baf656f4258360a9208bac00fc648ee20f9d4:E_commerce_Product_Catalog.Service/Commands/CartManagement/add/AddToCartHandler.cs
{
    public class AddToCartHandler : IRequestHandler<AddToCartCommand>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;

        public AddToCartHandler(ICartRepository cartRepository, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }

        public async Task Handle(AddToCartCommand request, CancellationToken cancellationToken)
        {
            if (request.Quantity <= 0)
                throw new InvalidQuantitiyOfCartItemExeption(request.ProductId);

            var product = await _productRepository.GetProductByIdAsync(request.ProductId);
            if (product == null) throw new InvalidOperationException("Product not found");

            var cart = await _cartRepository.GetCartByUserIdAsync(request.UserId) ?? new Cart { UserId = request.UserId };

            var item = cart.Items.FirstOrDefault(i => i.ProductId == request.ProductId);
            if (item == null)
            {
                cart.Items.Add(new CartItem { ProductId = request.ProductId, Quantity = request.Quantity });
            }
            else
            {
                item.Quantity += request.Quantity;
            }

            if (!await _cartRepository.ContainsCartAsync(cart.Id))
                await _cartRepository.AddCartAsync(cart);
        }
    }
}