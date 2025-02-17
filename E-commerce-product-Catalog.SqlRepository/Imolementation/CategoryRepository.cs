
using E_commerce_product_catalog.Models;
using E_commerce_Product_Catalog.Service.Abstractions;
using E_commerce_product_Catalog.SqlRepository.Database;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_product_Catalog.SqlRepository.Imolementation
{
    internal sealed class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Category> AddCategoryAsync(Category category)
        {
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return category;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(Guid id)
        {
            return await _dbContext.Categories.FindAsync(id);
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            var existingCategory = await _dbContext.Categories.FindAsync(category.Id);
            if (existingCategory != null)
            {
                existingCategory.CategoryName = category.CategoryName;
                _dbContext.Categories.Update(existingCategory);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task RemoveCategoryAsync(Guid id)
        {
            var category = await _dbContext.Categories.FindAsync(id);
            if (category != null)
            {
                _dbContext.Categories.Remove(category);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}