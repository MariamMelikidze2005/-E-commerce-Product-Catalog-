using E_commerce_Product_Catalog.Service.Models;
using E_commerce_Product_Catalog.Service.Services.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class E_commerceController : ControllerBase
    {

        private readonly UserService _userService;
        private readonly CategoryService  _categoryService;
        private readonly ProductService _productService;
        private readonly OrderService _orderService;
        private readonly CartService _cartService;

        public E_commerceController(UserService userService, CategoryService categoryService, ProductService productService, OrderService orderService, CartService cartService)
        {
            _userService = userService;
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _cartService = cartService;
        }

        [HttpPost("Register")]
        public async Task<User> RegisterAsync( string name, string email, string password)
        {
           return await _userService.RegisterUserAsync(name, email, password);
        }
    }
}
