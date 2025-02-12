using E_commerce_product_catalog.Abstraction;
using E_commerce_product_catalog.Models;
using MediatR;

namespace E_commerce_Product_Catalog.Service.Commands.CartManagement
{
    public class GetCartItemsHandler : IRequestHandler<GetCartItemsQuery, List<CartItem>>
    {
        private readonly ICartRepository _cartRepository;

        public GetCartItemsHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<List<CartItem>> Handle(GetCartItemsQuery request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetCartByUserIdAsync(request.UserId);
            return cart?.Items ?? new List<CartItem>();
        }
    }
}