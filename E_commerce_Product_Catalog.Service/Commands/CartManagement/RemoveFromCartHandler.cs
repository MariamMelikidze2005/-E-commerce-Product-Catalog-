using E_commerce_product_catalog.Abstraction;
using MediatR;
using ICartRepository = E_commerce_Product_Catalog.Service.Services.Abstractions.ICartRepository;

namespace E_commerce_Product_Catalog.Service.Commands.CartManagement
{
    public class RemoveFromCartHandler : IRequestHandler<RemoveFromCartCommand>
    {
        private readonly ICartRepository _cartRepository;

        public RemoveFromCartHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task Handle(RemoveFromCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetCartByUserIdAsync(request.UserId);
            if (cart == null) throw new InvalidOperationException("Cart not found for this user.");

            var item = cart.Items.FirstOrDefault(i => i.ProductId == request.ProductId);
            if (item == null) throw new InvalidOperationException("Product not found in cart.");

            cart.Items.Remove(item);

            if (cart.Items.Count == 0)
                await _cartRepository.RemoveCartAsync(cart);
            else
                await _cartRepository.UpdateCartAsync(cart);
        }
    }
}