using E_commerce_product_catalog.Abstraction;
using E_commerce_product_catalog.Abstraction.E_commerce_Product_Catalog.Service.Services.Abstractions;
using E_commerce_product_catalog.Models;
using E_commerce_product_catalog.Exceptions;

namespace E_commerce_Product_Catalog.Service.Services.Abstractions
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new List<Product>();

        public async Task<Product> AddProduct(Product product)
        {
            if (_products.Any(p => p.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase)))
                throw new ProductAlreadyExistsException(product.Name);

            _products.Add(product);
            return product;
        }

        public Task<List<Product>> GetProductsByCategory(Guid categoryId) =>
            Task.FromResult(_products.Where(p => p.CategoryId == categoryId).ToList());

        public Task<List<Product>> GetProductsByOwner(Guid ownerId) =>
            Task.FromResult(_products.Where(p => p.OwnerId == ownerId).ToList());

        public async Task<List<Product>> GetAllProducts()
        {
            if (!_products.Any()) throw new ProductNotInThisException();
            return _products;
        }

        public async Task<Product> GetProductByIdAsync(Guid productId)
        {
            var product = _products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
                throw new ProductNotFoundException(productId);

            return product;
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
