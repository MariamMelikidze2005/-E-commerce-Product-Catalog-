using E_commerce_Product_Catalog.Service.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_commerce_Product_Catalog.Service.Services.Abstractions
{
    public interface IOrderRepository
    {
        Task<Order> AddOrderAsync(Order order);
        Task<Order> GetOrderByIdAsync(Guid orderId);
        Task<List<Order>> GetOrdersByCustomerIdAsync(Guid customerId);
        Task UpdateOrderAsync(Order order);
        Task RemoveOrderAsync(Guid orderId);
    }
}
