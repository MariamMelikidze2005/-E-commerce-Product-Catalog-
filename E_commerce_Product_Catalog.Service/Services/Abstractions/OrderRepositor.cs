using E_commerce_product_catalog.Abstraction;
using E_commerce_product_catalog.Models;

namespace E_commerce_Product_Catalog.Service.Services.Abstractions
{
    public class OrderRepository : IOrderRepository
    {
        private readonly List<Order> _orders = new List<Order>();

        public async Task<Order> AddOrderAsync(Order order)
        {
            _orders.Add(order);
            return order;
        }

        public Task<Order?> GetOrderByIdAsync(Guid orderId) =>
            Task.FromResult(_orders.FirstOrDefault(o => o.Id == orderId));

        public async Task<List<Order>> GetOrdersByCustomerIdAsync(Guid customerId)
        {
            var orders = _orders.Where(o => o.CustomerId == customerId).ToList();
            return orders;
        }

        public async Task UpdateOrderAsync(Order order)
        {
            var existingOrder = _orders.FirstOrDefault(o => o.Id == order.Id);
            if (existingOrder != null)
            {
                existingOrder.Status = order.Status;
                existingOrder.TotalPrice = order.TotalPrice;
                existingOrder.Items = order.Items;
            }
        }

        public async Task RemoveOrderAsync(Guid orderId)
        {
            var order = _orders.FirstOrDefault(o => o.Id == orderId);
            if (order != null)
            {
                _orders.Remove(order);
            }
        }
    }
}