using E_commerce_product_catalog.Abstraction;
using E_commerce_product_catalog.Exceptions;
using MediatR;

namespace E_commerce_Product_Catalog.Service.Commands.OrderManagement
{
    public class CancelOrderHandler : IRequestHandler<CancelOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public CancelOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderByIdAsync(request.OrderId);
            if (order == null) throw new OrderNotFoundException(request.OrderId);
            if (order.Status != "Pending") throw new InvalidOperationException("Only orders with 'Pending' status can be cancelled.");

            order.Status = "Canceled";
            await _orderRepository.UpdateOrderAsync(order);
        }
    }
}