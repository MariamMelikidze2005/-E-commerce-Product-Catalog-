using E_commerce_Product_Catalog.Service.Exceptions;
using E_commerce_Product_Catalog.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_Product_Catalog.Service.Services.inplementation
{
    public class OrderService
    {
        private List<Order> _orders = new List<Order>();



        public Order PlaceOrder(Guid customerId, List<CartItem> cartItems, Func<Guid, decimal> getPrice)
        {
            if (!cartItems.Any()) throw new InvalidOperationException("this cart is empty");
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
            _orders.Add(order);
            return order;
        }

        public void CancelOrder(Guid orderId)
        {
            var order = _orders.FirstOrDefault(o => o.Id == orderId);
            if (order != null) { throw new OrderNotFoundException(orderId); }
            if (order.Status != "Pending") { throw new InvalidOperationException("Only orders with 'Pending' status can be cancelled."); }
            order.Status = "Canceled";
        }
        public void ConfirmeOrder(Guid orderId)
        {
            var order = _orders.FirstOrDefault(o => o.Id == orderId);
            if (order == null)
            {
                throw new OrderNotFoundException(orderId);
            }

            if (order.Status != "Pending")
            {
                throw new OrderCannotBeConfirmedException();
            }
            foreach (var item in order.Items)
            {
                var product = GetProductById(item.ProductId);
                if (product.Quantity < item.Quantity)
                {
                    throw new InsufficientStockException();
                }
                product.Quantity -= item.Quantity;
            }
            order.Status = "Confirmed";
        }
        public void CompletedOrder(Guid orderId)
        {
            var order = _orders.FirstOrDefault(o => o.Id == orderId);
            if (order == null) { throw new OrderNotFoundException(orderId); }

            if (order.Status != "Confirmed") { throw new InvalidOperationException("Only orders with 'Confirmed' status can be completed."); }
            order.Status = "Completed";
        }

        private Product GetProductById(Guid productId)
        {
            var product = _products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
            {
                throw new ProductNotFoundException(productId);
            }
            return product;
        }
        internal object PlaceOrder(Guid userId, List<CartItem> cartItem)
        {
            throw new NotImplementedException();//მისახედი გაქვს მარიამ
        }
    }
}
