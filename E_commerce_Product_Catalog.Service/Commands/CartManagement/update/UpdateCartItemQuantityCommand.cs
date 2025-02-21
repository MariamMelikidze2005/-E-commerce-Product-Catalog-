using MediatR;

namespace E_commerce_Product_Catalog.Service.Commands.CartManagement.update
{
    public class UpdateCartItemQuantityCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public int NewQuantity { get; set; }

        public UpdateCartItemQuantityCommand(Guid userId, Guid productId, int newQuantity)
        {
            UserId = userId;
            ProductId = productId;
            NewQuantity = newQuantity;
        }
    }
}