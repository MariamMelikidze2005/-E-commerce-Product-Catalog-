
using E_commerce_product_catalog.Models;
using E_commerce_Product_Catalog.Service.Abstractions;
using E_commerce_product_Catalog.SqlRepository.Database;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_product_Catalog.SqlRepository.Imolementation
{
    internal sealed class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
            return order;
        }

        public async Task<Order?> GetOrderByIdAsync(Guid orderId)
        {
            return await _dbContext.Orders
                .Include(o => o.Items) // Include Order Items if needed
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task<List<Order>> GetOrdersByCustomerIdAsync(Guid customerId)
        {
            return await _dbContext.Orders
                .Where(o => o.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task UpdateOrderAsync(Order order)
        {
            var existingOrder = await _dbContext.Orders.FindAsync(order.Id);
            if (existingOrder != null)
            {
                existingOrder.Status = order.Status;
                existingOrder.TotalPrice = order.TotalPrice;
                existingOrder.Items = order.Items;

                _dbContext.Orders.Update(existingOrder);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task RemoveOrderAsync(Guid orderId)
        {
            var order = await _dbContext.Orders.FindAsync(orderId);
            if (order != null)
            {
                _dbContext.Orders.Remove(order);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
