using MediatR;

namespace E_commerce_Product_Catalog.Service.Commands.CartManagement.remove
{
    public class RemoveFromCartCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }

        public RemoveFromCartCommand(Guid userId, Guid productId)
        {
            UserId = userId;
            ProductId = productId;
        }
    }
}