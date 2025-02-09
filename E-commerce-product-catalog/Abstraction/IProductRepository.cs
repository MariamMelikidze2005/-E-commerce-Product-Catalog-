using E_commerce_product_catalog.Models;

namespace E_commerce_product_catalog.Abstraction
{
   

    namespace E_commerce_Product_Catalog.Service.Services.Abstractions
    {
        public interface IProductRepository
        {
            Task<Product> AddProduct(Product product);
            Task<List<Product>> GetProductsByCategory(Guid categoryId);
            Task<List<Product>> GetProductsByOwner(Guid ownerId);
            Task<List<Product>> GetAllProducts();
            Task<Product> GetProductByIdAsync(Guid productId); 
            Task RemoveProduct(Guid productId);
            Task UpdateProduct(Product product);
        }
    }

}
