using MediatR;

namespace E_commerce_Product_Catalog.Service.Commands.OrderManagement.Confirm
{
    public class ConfirmOrderCommand : IRequest
    {
        public Guid OrderId { get; set; }

        public ConfirmOrderCommand(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}