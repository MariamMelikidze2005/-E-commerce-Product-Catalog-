using MediatR;
using ICartRepository = E_commerce_Product_Catalog.Service.Abstractions.ICartRepository;

<<<<<<<< HEAD:E_commerce_Product_Catalog.Service/Commands/CartManagement/Commands/RemoveFromCartHandler.cs
namespace E_commerce_Product_Catalog.Service.Commands.CartManagement.Commands
========
namespace E_commerce_Product_Catalog.Service.Commands.CartManagement.remove
>>>>>>>> 437baf656f4258360a9208bac00fc648ee20f9d4:E_commerce_Product_Catalog.Service/Commands/CartManagement/remove/RemoveFromCartHandler.cs
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
                await _cartRepository.RemoveCartAsync(cart.Id);
            else
                await _cartRepository.UpdateCartAsync(cart);
        }
    }
}