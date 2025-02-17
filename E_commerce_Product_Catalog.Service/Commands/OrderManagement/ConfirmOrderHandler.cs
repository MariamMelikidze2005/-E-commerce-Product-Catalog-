using E_commerce_product_catalog.Exceptions;
using E_commerce_Product_Catalog.Service.Abstractions;
using MediatR;
using IOrderRepository = E_commerce_Product_Catalog.Service.Abstractions.IOrderRepository;

namespace E_commerce_Product_Catalog.Service.Commands.OrderManagement
{
    public class ConfirmOrderHandler : IRequestHandler<ConfirmOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public ConfirmOrderHandler(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task Handle(ConfirmOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderByIdAsync(request.OrderId);
            if (order == null) throw new OrderNotFoundException(request.OrderId);
            if (order.Status != "Pending") throw new InvalidOperationException("Only orders with 'Pending' status can be confirmed.");

            foreach (var item in order.Items)
            {
                var product = await _productRepository.GetProductByIdAsync(item.ProductId);
                if (product.Quantity < item.Quantity)
                {
                    throw new InsufficientStockException();
                }
                product.Quantity -= item.Quantity;
            }

            order.Status = "Confirmed";
            await _orderRepository.UpdateOrderAsync(order);
        }
    }
}