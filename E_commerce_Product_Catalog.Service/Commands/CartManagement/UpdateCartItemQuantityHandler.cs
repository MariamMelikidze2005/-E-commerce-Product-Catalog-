using E_commerce_product_catalog.Abstraction;
using E_commerce_product_catalog.Abstraction.E_commerce_Product_Catalog.Service.Services.Abstractions;
using MediatR;
using ICartRepository = E_commerce_Product_Catalog.Service.Services.Abstractions.ICartRepository;

namespace E_commerce_Product_Catalog.Service.Commands.CartManagement
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
                await _cartRepository.RemoveCartAsync(cart);
            else
                await _cartRepository.UpdateCartAsync(cart);
        }
    }
}