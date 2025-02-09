using E_commerce_product_catalog.Abstraction;
using E_commerce_product_catalog.Abstraction.E_commerce_Product_Catalog.Service.Services.Abstractions;
using E_commerce_product_catalog.Exceptions;
using E_commerce_product_catalog.Models;

namespace E_commerce_Product_Catalog.Service.Services.inplementation
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<Order> PlaceOrderAsync(Guid customerId, List<CartItem> cartItems, Func<Guid, decimal> getPrice)
        {
            if (!cartItems.Any()) throw new InvalidOperationException("This cart is empty");

            var order = new Order
            {
                Id = Guid.NewGuid(),
                CustomerId = customerId,
                OrderDate = DateTime.Now,
                Items = cartItems.Select(ci => new OrderItem
                {
                    ProductId = ci.ProductId,
                    Quantity = ci.Quantity,
                    Price = getPrice(ci.ProductId)
                }).ToList(),
                TotalPrice = cartItems.Sum(ci => ci.Quantity * getPrice(ci.ProductId)),
                Status = "Pending",
            };

            await _orderRepository.AddOrderAsync(order);
            return order;
        }

        public async Task CancelOrderAsync(Guid orderId)
        {
            var order = await _orderRepository.GetOrderByIdAsync(orderId);
            if (order == null) throw new OrderNotFoundException(orderId);
            if (order.Status != "Pending") throw new InvalidOperationException("Only orders with 'Pending' status can be cancelled.");

            order.Status = "Canceled";
            await _orderRepository.UpdateOrderAsync(order);

        }

        public async Task ConfirmOrderAsync(Guid orderId)
        {
            var order = await _orderRepository.GetOrderByIdAsync(orderId);
            if (order == null) throw new OrderNotFoundException(orderId);
            if (order.Status != "Pending") throw new OrderCannotBeConfirmedException();

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

        public async Task CompleteOrderAsync(Guid orderId)
        {
            var order = await _orderRepository.GetOrderByIdAsync(orderId);
            if (order == null) throw new OrderNotFoundException(orderId);
            if (order.Status != "Confirmed") throw new InvalidOperationException("Only orders with 'Confirmed' status can be completed.");

            order.Status = "Completed";
            await _orderRepository.UpdateOrderAsync(order);
        }
    }
}
