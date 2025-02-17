using E_commerce_product_catalog.Models;

namespace E_commerce_Product_Catalog.Service.Abstractions
{
    public interface ICartRepository
    {
        Task<Cart?> GetCartByUserIdAsync(Guid userId);
        Task<List<Cart>> GetAllCartsAsync();
        Task<bool> ContainsCartAsync(Guid userId);
        Task AddCartAsync(Cart cart);
        Task UpdateCartAsync(Cart cart);
        Task RemoveCartAsync(Guid userId);
    }
}