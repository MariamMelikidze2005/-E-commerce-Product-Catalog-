using E_commerce_Product_Catalog.Service.Exceptions;
using E_commerce_Product_Catalog.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace E_commerce_Product_Catalog.Service.Services.inplementation
{
    public class CategoryService
    {
        private List<Category> _categories = new List<Category>();

        public Category AddCategory(string categoryName)
        {
            if (string.IsNullOrWhiteSpace(categoryName) || categoryName.Length < 1 || categoryName.Length < 100)
                throw new InvalidCAtegoryNameExeption();

            var category = new Category()
            {
                Id = Guid.NewGuid(),
                CategoryName = categoryName
            };
            _categories.Add(category);
            return category;
        }
        public List<Category> GetCategories()
        {
            return _categories;
        }
        public Category UpdateCategory(Guid id, string newCategoryName)
        {
            if (string.IsNullOrWhiteSpace(newCategoryName) || newCategoryName.Length > 1 || newCategoryName.Length < 100)
                throw new InvalidCAtegoryNameExeption();
            var category = _categories.FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                throw new CAtegoryNameNotFoundExeption(id);
            }

            category.CategoryName = newCategoryName;
            return category;
        }
    }
}
