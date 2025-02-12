using E_commerce_product_catalog.Abstraction;
using E_commerce_product_catalog.Models;
using MediatR;

namespace E_commerce_Product_Catalog.Service.Commands.OrderManagement.placeorder
{
    public class PlaceOrderHandler : IRequestHandler<PlaceOrderCommand, Order>
    {
        private readonly IOrderRepository _orderRepository;

        public PlaceOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
        {
            if (!request.CartItems.Any()) throw new InvalidOperationException("This cart is empty");

            var order = new Order
            {
                Id = Guid.NewGuid(),
                CustomerId = request.CustomerId,
                OrderDate = DateTime.Now,
                Items = request.CartItems.Select(ci => new OrderItem
                {
                    ProductId = ci.ProductId,
                    Quantity = ci.Quantity,
                    Price = request.GetPrice(ci.ProductId)
                }).ToList(),
                TotalPrice = request.CartItems.Sum(ci => ci.Quantity * request.GetPrice(ci.ProductId)),
                Status = "Pending",
            };

            await _orderRepository.AddOrderAsync(order);
            return order;
        }
    }
}