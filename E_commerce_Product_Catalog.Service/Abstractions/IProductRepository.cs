using E_commerce_product_catalog.Models;

namespace E_commerce_Product_Catalog.Service.Abstractions
{
    public interface IProductRepository
    {
        Task<Product> AddProductAsync(Product product);
        Task<Product?> GetProductByIdAsync(Guid productId);
        Task<List<Product>> GetAllProductsAsync();
        Task<List<Product>> GetProductsByCategoryAsync(Guid categoryId);
        Task<List<Product>> GetProductsByOwnerAsync(Guid ownerId);
        Task UpdateProductAsync(Product product);
        Task RemoveProductAsync(Guid productId);
    }
}