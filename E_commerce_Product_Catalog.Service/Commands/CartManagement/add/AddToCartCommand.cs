using MediatR;

<<<<<<<< HEAD:E_commerce_Product_Catalog.Service/Commands/CartManagement/Commands/AddToCartCommand.cs
namespace E_commerce_Product_Catalog.Service.Commands.CartManagement.Commands
========
namespace E_commerce_Product_Catalog.Service.Commands.CartManagement.add
>>>>>>>> 437baf656f4258360a9208bac00fc648ee20f9d4:E_commerce_Product_Catalog.Service/Commands/CartManagement/add/AddToCartCommand.cs
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