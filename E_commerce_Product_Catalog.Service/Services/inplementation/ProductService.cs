using E_commerce_Product_Catalog.Service.Commands;
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
    public class ProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly AddProductCommand _addProductCommand;

        public ProductService(IProductRepository productRepository, AddProductCommand addProductCommand)
        {
            _productRepository = productRepository;
            _addProductCommand = addProductCommand;
        }

        public async Task<Product> AddProduct(string name, string description, decimal price, int quantity, Guid categoryId, Guid ownerId)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                Price = price,
                Quantity = quantity,
                CategoryId = categoryId,
                OwnerId = ownerId
            };

            var validationResult = _addProductCommand.Validate(product);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ArgumentException($"Validation failed: {errors}");
            }

            return await _productRepository.AddProduct(product); 
        }

        public async Task<List<Product>> GetProductsByCategory(Guid categoryId)
        {
            return await _productRepository.GetProductsByCategory(categoryId);
        }

        public async Task<List<Product>> GetProductsByOwner(Guid ownerId)
        {
            return await _productRepository.GetProductsByOwner(ownerId); 
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _productRepository.GetAllProducts();
        }

        public async Task<Product> GetProductById(Guid productId)
        {
            return await _productRepository.GetProductById(productId);
        }

        public async Task RemoveProduct(Guid productId)
        {
            await _productRepository.RemoveProduct(productId); 
        }

        public async Task UpdateProduct(Guid productId, string name, string description, decimal price, int quantity, Guid categoryId)
        {
            var product = await _productRepository.GetProductById(productId); 
            product.Name = name ?? product.Name;
            product.Description = description ?? product.Description;
            product.Price = price != 0 ? price : product.Price;
            product.Quantity = quantity >= 0 ? quantity : product.Quantity;
            product.CategoryId = categoryId != Guid.Empty ? categoryId : product.CategoryId;

            await _productRepository.UpdateProduct(product); 
        }
    }
}
