using E_commerce_Product_Catalog.Service.Models;
using E_commerce_Product_Catalog.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce_Product_Catalog.Service.Services.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly List<Order> _orders = new List<Order>();

        public async Task<Order> AddOrderAsync(Order order)
        {
            _orders.Add(order);
            return await Task.FromResult(order);
        }

        public async Task<Order> GetOrderByIdAsync(Guid orderId)
        {
            var order = _orders.FirstOrDefault(o => o.Id == orderId);
            return await Task.FromResult(order); 
        }

        public async Task<List<Order>> GetOrdersByCustomerIdAsync(Guid customerId)
        {
            var orders = _orders.Where(o => o.CustomerId == customerId).ToList();
            return await Task.FromResult(orders);
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
            await Task.CompletedTask;
        }

        public async Task RemoveOrderAsync(Guid orderId)
        {
            var order = _orders.FirstOrDefault(o => o.Id == orderId);
            if (order != null)
            {
                _orders.Remove(order);
            }
            await Task.CompletedTask;
        }
    }
}
