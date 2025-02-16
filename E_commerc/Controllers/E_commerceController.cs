////using E_commerce_Product_Catalog.Service.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using E_commerce_product_catalog.Models;
//using E_commerce_Product_Catalog.Service.Services.inplementation;

//namespace E_commerc.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class E_commerceController : ControllerBase
//    {

//        private readonly UserService _userService;
//        private readonly CategoryService _categoryService;
//        private readonly ProductService _productService;
//        private readonly OrderService _orderService;
//        private readonly CartService _cartService;

//        public E_commerceController(UserService userService, CategoryService categoryService, ProductService productService, OrderService orderService, CartService cartService)
//        {
//            _userService = userService;
//            _categoryService = categoryService;
//            _productService = productService;
//            _orderService = orderService;
//            _cartService = cartService;
//        }

//        [HttpPost("Register")]
//        public async Task<User> RegisterAsync(string name, string email, string password)
//        {
//            return await _userService.RegisterUserAsync(name, email, password);
//        }

//        [HttpPost("PlaceOrder")]
//        public async Task<Order> PlaceOrderAsync(Guid customerId, List<CartItem> cartItems, Func<Guid, decimal> getPrice)
//        {
//            return await _orderService.PlaceOrderAsync(customerId,cartItems, getPrice);
//        }

//        [HttpPost("CancelOrder")]
//        public async void CancelOrderAsync(Guid orderId)
//        {
//             await _orderService.CancelOrderAsync(orderId);
//        }

//        [HttpPost("ConfirmOrder")]
//        public async void ConfirmOrderAsync(Guid orderId)
//        {
//             await _orderService.ConfirmOrderAsync(orderId);
//        }

//        [HttpPost("CompleteOrder")]
//        public async void CompleteOrderAsync(Guid orderId)
//        {
//            await _orderService.CompleteOrderAsync(orderId);
//        }

//        [HttpPost("AddCategory")]
//        public async Task<Category> AddCategoryAsync(string categoryName)
//        {
//            return await _categoryService.AddCategoryAsync(categoryName);
//        }

//        [HttpPost("UpdateCategory")]
//        public async Task<Category> UpdateCategoryAsync(Guid id, string newCategoryName)
//        {
//            return await _categoryService.UpdateCategoryAsync(id, newCategoryName);
//        }



//        [HttpPost("GetCartItems")]
//        public async Task<List<CartItem>> GetCartItemsAsync(Guid userId)
//        {
//            return await _cartService.GetCartItemsAsync(userId);
//        }


//    }
//}
