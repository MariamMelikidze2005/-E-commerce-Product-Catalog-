using E_commerce_product_catalog.Models;
using MediatR;

namespace E_commerce_Product_Catalog.Service.Commands.OrderManagement
{
    public class PlaceOrderCommand : IRequest<Order>
    {
        public Guid CustomerId { get; set; }
        public List<CartItem> CartItems { get; set; }
        public Func<Guid, decimal> GetPrice { get; set; }

        public PlaceOrderCommand(Guid customerId, List<CartItem> cartItems, Func<Guid, decimal> getPrice)
        {
            CustomerId = customerId;
            CartItems = cartItems;
            GetPrice = getPrice;
        }
    }
}