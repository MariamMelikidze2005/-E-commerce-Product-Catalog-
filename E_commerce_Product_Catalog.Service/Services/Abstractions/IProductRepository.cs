using E_commerce_Product_Catalog.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_Product_Catalog.Service.Services.Abstractions
{
    using E_commerce_Product_Catalog.Service.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

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
