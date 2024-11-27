using E_commerce_Product_Catalog.Service.Commands;
using E_commerce_Product_Catalog.Service.Exceptions;
using E_commerce_Product_Catalog.Service.Models;
using E_commerce_Product_Catalog.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace E_commerce_Product_Catalog.Service.Services.inplementation
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

        public Product AddProduct(string name, string description, decimal price, int quantity, Guid categoryId, Guid ownerId)
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

            // ვალიდაციის პროცესი
            var validationResult = _addProductCommand.Validate(product);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ArgumentException($"Validation failed: {errors}");
            }

            return _productRepository.AddProduct(product);
        }

        public List<Product> GetProductsByCategory(Guid categoryId)
        {
            return _productRepository.GetProductsByCategory(categoryId);
        }

        public List<Product> GetProductsByOwner(Guid ownerId)
        {
            return _productRepository.GetProductsByOwner(ownerId);
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public Product GetProductById(Guid productId)
        {
            return _productRepository.GetProductById(productId);
        }

        public void RemoveProduct(Guid productId)
        {
            _productRepository.RemoveProduct(productId);
        }

        public void UpdateProduct(Guid productId, string name, string description, decimal price, int quantity, Guid categoryId)
        {
            var product = _productRepository.GetProductById(productId);
            product.Name = name ?? product.Name;
            product.Description = description ?? product.Description;
            product.Price = price != 0 ? price : product.Price;
            product.Quantity = quantity >= 0 ? quantity : product.Quantity;
            product.CategoryId = categoryId != Guid.Empty ? categoryId : product.CategoryId;

            _productRepository.UpdateProduct(product);
        }

    }
}
