using E_commerce_Product_Catalog.Service.Exceptions;
using E_commerce_Product_Catalog.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace E_commerce_Product_Catalog.Service.Services.inplementation
{
    public class ProductService
    {
        private List<Product> _products = new List<Product>();


        public Product AddProduct(string name, string description, decimal price, int quantity, Guid categoryId, Guid ownerId)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length > 100)
                throw new InvalidProductNameException();

            if (price <= 0)
                throw new InvalidProductPriceException();

            if (quantity < 0)
                throw new InvalidProductQuantityException();

            if (_products.Any(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
                throw new ProductAlreadyExistsException(name);

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

            _products.Add(product);

            return product;
        }


        public List<Product> GetProductsByCategory(Guid categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();


        }

        public List<Product> GetProductsByOwner(Guid ownerId)
        {
            return _products.Where(p => p.OwnerId == ownerId).ToList();

        }

        public List<Product> GetAllProducts()
        {
            if (!_products.Any())
                throw new ProductNotInThisException();
            return _products;
        }

        public Product GetProductById(Guid productId)
        {
            var product = _products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
            {
                throw new ProductNotFoundException(productId);
            }
            return product;
        }

        public void RemoveProduct(Guid productId)
        {
            var product = GetProductById(productId);
            _products.Remove(product);
        }

        public void UpdateProduct(Guid productId, string name, string description, decimal price, int quantity, Guid categoryId)
        {
            var product = GetProductById(productId);

            if (!string.IsNullOrWhiteSpace(name) && name.Length > 100)
                throw new InvalidProductNameException();

            if (price <= 0)
                throw new InvalidProductPriceException();

            if (quantity < 0)
                throw new InvalidProductQuantityException();

            product.Name = name ?? product.Name;
            product.Description = description ?? product.Description;
            product.Price = price != 0 ? price : product.Price;
            product.Quantity = quantity >= 0 ? quantity : product.Quantity;
            product.CategoryId = categoryId != Guid.Empty ? categoryId : product.CategoryId;
        }

    }
}
