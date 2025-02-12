using E_commerce_product_catalog.Models;
using MediatR;

namespace E_commerce_Product_Catalog.Service.Commands.CartManagement
{
    public class GetCartItemsQuery : IRequest<List<CartItem>>
    {
        public Guid UserId { get; set; }

        public GetCartItemsQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}