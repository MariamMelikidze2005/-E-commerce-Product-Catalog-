
using E_commerce_product_catalog.Exceptions;
using E_commerce_product_catalog.Models;
using E_commerce_Product_Catalog.Service.Abstractions;
using E_commerce_product_Catalog.SqlRepository.Database;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_product_Catalog.SqlRepository.Imolementation
{
    internal sealed class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            if (await _dbContext.Products.AnyAsync(p => p.Name == product.Name))
                throw new ProductAlreadyExistsException(product.Name);

            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetProductsByCategory(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetProductsByOwner(Guid ownerId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public async Task<Product?> GetProductByIdAsync(Guid productId)
        {
            return await _dbContext.Products.FindAsync(productId)
                ?? throw new ProductNotFoundException(productId);
        }

        public async Task RemoveProduct(Guid productId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            var products = await _dbContext.Products.ToListAsync();
            if (!products.Any())
                throw new ProductNotInThisException();
            return products;
        }

        public async Task<List<Product>> GetProductsByCategoryAsync(Guid categoryId)
        {
            return await _dbContext.Products
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<List<Product>> GetProductsByOwnerAsync(Guid ownerId)
        {
            return await _dbContext.Products
                .Where(p => p.OwnerId == ownerId)
                .ToListAsync();
        }

        public async Task UpdateProductAsync(Product updatedProduct)
        {
            var existingProduct = await GetProductByIdAsync(updatedProduct.Id);

            if (existingProduct != null)
            {
                existingProduct.Name = updatedProduct.Name ?? existingProduct.Name;
                existingProduct.Description = updatedProduct.Description ?? existingProduct.Description;
                existingProduct.Price = updatedProduct.Price != 0 ? updatedProduct.Price : existingProduct.Price;
                existingProduct.Quantity =
                    updatedProduct.Quantity >= 0 ? updatedProduct.Quantity : existingProduct.Quantity;
                existingProduct.CategoryId = updatedProduct.CategoryId != Guid.Empty
                    ? updatedProduct.CategoryId
                    : existingProduct.CategoryId;

                _dbContext.Products.Update(existingProduct);
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveProductAsync(Guid productId)
        {
            var product = await GetProductByIdAsync(productId);
            if (product != null) _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
        }
    }
}
