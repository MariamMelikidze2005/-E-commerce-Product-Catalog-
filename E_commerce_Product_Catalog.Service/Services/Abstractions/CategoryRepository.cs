using E_commerce_Product_Catalog.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_Product_Catalog.Service.Services.Abstractions
{
    public class CategoryRepository : ICategoryRepository
    {
        private List<Category> _categories = new List<Category>();

        public async Task<Category> AddCategoryAsync(Category category)
        {
            await Task.Run(() => _categories.Add(category));
            return category;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await Task.FromResult(_categories);
        }

        public async Task<Category> GetCategoryByIdAsync(Guid id)
        {
            return await Task.FromResult(_categories.FirstOrDefault(c => c.Id == id));
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            await Task.Run(() =>
            {
                var existingCategory = _categories.FirstOrDefault(c => c.Id == category.Id);
                if (existingCategory != null)
                {
                    existingCategory.CategoryName = category.CategoryName;
                }
            });
        }

        public async Task RemoveCategoryAsync(Guid id)
        {
            await Task.Run(() =>
            {
                var category = _categories.FirstOrDefault(c => c.Id == id);
                if (category != null)
                {
                    _categories.Remove(category);
                }
            });
        }

      
    }

}
