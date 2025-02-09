using E_commerce_product_catalog.Abstraction;
using E_commerce_product_catalog.Models;

namespace E_commerce_Product_Catalog.Service.Services.Abstractions
{
    public class CategoryRepository : ICategoryRepository
    {
        private List<Category> _categories = new List<Category>();

        public async Task<Category> AddCategoryAsync(Category category)
        {
            _categories.Add(category);
            return category;
        }

        public Task<List<Category>> GetCategoriesAsync() => Task.FromResult(_categories);

        public async Task<Category?> GetCategoryByIdAsync(Guid id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            return category;
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            var existingCategory = _categories.FirstOrDefault(c => c.Id == category.Id);
            if (existingCategory != null)
            {
                existingCategory.CategoryName = category.CategoryName;
            }
        }

        public async Task RemoveCategoryAsync(Guid id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category != null)
            {
                _categories.Remove(category);
            }
        }
    }
}