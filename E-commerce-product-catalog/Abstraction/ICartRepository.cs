using E_commerce_product_catalog.Models;

namespace E_commerce_product_catalog.Abstraction
{
    public interface ICartRepository
    {
        Task<Cart?> GetCartByUserIdAsync(Guid userId);
        Task AddCartAsync(Cart cart);
        Task UpdateCartAsync(Cart cart);
        Task RemoveCartAsync(Cart cart);
        Task<List<Cart>> GetAllCartsAsync();
        Task<bool> ContainsCartAsync(Cart cart);  // Make this asynchronous
    }

}
