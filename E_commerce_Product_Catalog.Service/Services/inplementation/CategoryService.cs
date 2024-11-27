using E_commerce_Product_Catalog.Service.Commands;
using E_commerce_Product_Catalog.Service.Exceptions;
using E_commerce_Product_Catalog.Service.Models;
using E_commerce_Product_Catalog.Service.Repositories;
using E_commerce_Product_Catalog.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace E_commerce_Product_Catalog.Service.Services.implementation
{
    public class CategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly AddCategoryCommand _addCategoryCommand;

        public CategoryService(ICategoryRepository categoryRepository, AddCategoryCommand addCategoryCommand)
        {
            _categoryRepository = categoryRepository;
            _addCategoryCommand = addCategoryCommand;
        }

        public Category AddCategory(string categoryName)
        {
            var category = new Category()
            {
                Id = Guid.NewGuid(),
                CategoryName = categoryName
            };

            // ვალიდაცია
            var validationResult = _addCategoryCommand.Validate(category);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ArgumentException($"Validation failed: {errors}");
            }

            return _categoryRepository.AddCategory(category);
        }

        public List<Category> GetCategories()
        {
            return _categoryRepository.GetCategories();
        }

        public Category UpdateCategory(Guid id, string newCategoryName)
        {
            if (string.IsNullOrWhiteSpace(newCategoryName) || newCategoryName.Length > 100)
                throw new InvalidCAtegoryNameExeption();

            var category = _categoryRepository.GetCategoryById(id);
            if (category == null)
            {
                throw new CAtegoryNameNotFoundExeption(id);
            }

            category.CategoryName = newCategoryName;
            _categoryRepository.UpdateCategory(category);
            return category;
        }

        public void RemoveCategory(Guid id)
        {
            _categoryRepository.RemoveCategory(id);
        }
    }
}
