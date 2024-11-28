using E_commerce_Product_Catalog.Service.Commands;
using E_commerce_Product_Catalog.Service.Exceptions;
using E_commerce_Product_Catalog.Service.Models;
using E_commerce_Product_Catalog.Service.Services.Abstractions;

public class CategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly AddCategoryCommand _addCategoryCommand;

    public CategoryService(ICategoryRepository categoryRepository, AddCategoryCommand addCategoryCommand)
    {
        _categoryRepository = categoryRepository;
        _addCategoryCommand = addCategoryCommand;
    }

    public async Task<Category> AddCategoryAsync(string categoryName)
    {
        var category = new Category
        {
            Id = Guid.NewGuid(),
            CategoryName = categoryName
        };

        // ვალიდაციის გამოძახება Command-დან
        var validationResult = _addCategoryCommand.Validate(category);
        if (!validationResult.IsValid)
        {
            var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
            throw new ArgumentException($"Validation failed: {errors}");
        }

        return await _categoryRepository.AddCategoryAsync(category);
    }

    public async Task<List<Category>> GetCategoriesAsync()
    {
        return await _categoryRepository.GetCategoriesAsync();
    }

    public async Task<Category> UpdateCategoryAsync(Guid id, string newCategoryName)
    {
        var category = await _categoryRepository.GetCategoryByIdAsync(id);
        if (category == null)
        {
            throw new CAtegoryNameNotFoundExeption(id);
        }

        category.CategoryName = newCategoryName;

        // ვალიდაციის გამოძახება Command-დან
        var validationResult = _addCategoryCommand.Validate(category);
        if (!validationResult.IsValid)
        {
            var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
            throw new ArgumentException($"Validation failed: {errors}");
        }

        await _categoryRepository.UpdateCategoryAsync(category);
        return category;
    }

    public async Task RemoveCategoryAsync(Guid id)
    {
        var category = await _categoryRepository.GetCategoryByIdAsync(id);
        if (category == null)
        {
            throw new CAtegoryNameNotFoundExeption(id);
        }

        await _categoryRepository.RemoveCategoryAsync(id);
    }
}
