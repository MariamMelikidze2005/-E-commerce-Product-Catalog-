using E_commerce_Product_Catalog.Service.Exceptions;
using E_commerce_Product_Catalog.Service.Models;
using E_commerce_Product_Catalog.Service.Services.Abstractions;
using E_commerce_Product_Catalog.Service.Services.Abstractions.E_commerce_Product_Catalog.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce_Product_Catalog.Service.Services.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new();

        public async Task<Product> AddProduct(Product product)
        {
            if (_products.Any(p => p.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase)))
                throw new ProductAlreadyExistsException(product.Name);

            _products.Add(product);
            return await Task.FromResult(product);
        }

        public async Task<List<Product>> GetProductsByCategory(Guid categoryId)
        {
            var products = _products.Where(p => p.CategoryId == categoryId).ToList();
            return await Task.FromResult(products);
        }

        public async Task<List<Product>> GetProductsByOwner(Guid ownerId)
        {
            var products = _products.Where(p => p.OwnerId == ownerId).ToList();
            return await Task.FromResult(products);
        }

        public async Task<List<Product>> GetAllProducts()
        {
            if (!_products.Any())
                throw new ProductNotInThisException();

            return await Task.FromResult(_products);
        }

        public async Task<Product> GetProductByIdAsync(Guid productId)
        {
            var product = _products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
                throw new ProductNotFoundException(productId);

            return await Task.FromResult(product);  
        }

        public async Task RemoveProduct(Guid productId)
        {
            var product = await GetProductByIdAsync(productId);
            _products.Remove(product);
        }

        public async Task UpdateProduct(Product updatedProduct)
        {
            var existingProduct = await GetProductByIdAsync(updatedProduct.Id);
            existingProduct.Name = updatedProduct.Name ?? existingProduct.Name;
            existingProduct.Description = updatedProduct.Description ?? existingProduct.Description;
            existingProduct.Price = updatedProduct.Price != 0 ? updatedProduct.Price : existingProduct.Price;
            existingProduct.Quantity = updatedProduct.Quantity >= 0 ? updatedProduct.Quantity : existingProduct.Quantity;
            existingProduct.CategoryId = updatedProduct.CategoryId != Guid.Empty ? updatedProduct.CategoryId : existingProduct.CategoryId;
        }
    }
}
