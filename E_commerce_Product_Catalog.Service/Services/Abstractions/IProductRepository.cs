using E_commerce_Product_Catalog.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_Product_Catalog.Service.Services.Abstractions
{
    public interface IProductRepository
    {
        Product AddProduct(Product product);
        List<Product> GetProductsByCategory(Guid categoryId);
        List<Product> GetProductsByOwner(Guid ownerId);
        List<Product> GetAllProducts();
        Product GetProductById(Guid productId);
        void RemoveProduct(Guid productId);
        void UpdateProduct(Product product);
    }
}
