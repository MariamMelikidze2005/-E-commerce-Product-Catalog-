
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using E_commerce_product_catalog.Models;

namespace E_commerce_product_catalog.Abstraction
{
    public interface IOrderRepository
    {
        Task<Order> AddOrderAsync(Order order);
        Task<Order?> GetOrderByIdAsync(Guid orderId);
        Task<List<Order>> GetOrdersByCustomerIdAsync(Guid customerId);
        Task UpdateOrderAsync(Order order);
        Task RemoveOrderAsync(Guid orderId);
    }
}
