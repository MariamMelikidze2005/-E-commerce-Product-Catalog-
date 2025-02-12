using MediatR;

namespace E_commerce_Product_Catalog.Service.Commands.ProductManagement
{
    public class RemoveProductCommand : IRequest
    {
        public Guid ProductId { get; set; }

        public RemoveProductCommand(Guid productId)
        {
            ProductId = productId;
        }
    }
}