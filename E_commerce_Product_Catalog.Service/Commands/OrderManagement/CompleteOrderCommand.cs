using MediatR;

namespace E_commerce_Product_Catalog.Service.Commands.OrderManagement
{
    public class CompleteOrderCommand : IRequest
    {
        public Guid OrderId { get; set; }

        public CompleteOrderCommand(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}