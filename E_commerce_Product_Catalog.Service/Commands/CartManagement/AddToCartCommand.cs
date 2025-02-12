using MediatR;

namespace E_commerce_Product_Catalog.Service.Commands.CartManagement
{
    public class AddToCartCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        public AddToCartCommand(Guid userId, Guid productId, int quantity)
        {
            UserId = userId;
            ProductId = productId;
            Quantity = quantity;
        }
    }
}