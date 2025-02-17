using MediatR;

<<<<<<<< HEAD:E_commerce_Product_Catalog.Service/Commands/CartManagement/Commands/RemoveFromCartCommand.cs
namespace E_commerce_Product_Catalog.Service.Commands.CartManagement.Commands
========
namespace E_commerce_Product_Catalog.Service.Commands.CartManagement.remove
>>>>>>>> 437baf656f4258360a9208bac00fc648ee20f9d4:E_commerce_Product_Catalog.Service/Commands/CartManagement/remove/RemoveFromCartCommand.cs
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