using MediatR;

<<<<<<<< HEAD:E_commerce_Product_Catalog.Service/Commands/CartManagement/Commands/UpdateCartItemQuantityCommand.cs
namespace E_commerce_Product_Catalog.Service.Commands.CartManagement.Commands
========
namespace E_commerce_Product_Catalog.Service.Commands.CartManagement.update
>>>>>>>> 437baf656f4258360a9208bac00fc648ee20f9d4:E_commerce_Product_Catalog.Service/Commands/CartManagement/update/UpdateCartItemQuantityCommand.cs
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