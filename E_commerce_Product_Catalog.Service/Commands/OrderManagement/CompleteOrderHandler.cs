using E_commerce_product_catalog.Exceptions;
using MediatR;
using IOrderRepository = E_commerce_Product_Catalog.Service.Abstractions.IOrderRepository;

namespace E_commerce_Product_Catalog.Service.Commands.OrderManagement
{
    public class CompleteOrderHandler : IRequestHandler<CompleteOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public CompleteOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Handle(CompleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderByIdAsync(request.OrderId);
            if (order == null) throw new OrderNotFoundException(request.OrderId);
            if (order.Status != "Confirmed") throw new InvalidOperationException("Only orders with 'Confirmed' status can be completed.");

            order.Status = "Completed";
            await _orderRepository.UpdateOrderAsync(order);
        }
    }
}