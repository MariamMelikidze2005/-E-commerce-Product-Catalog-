using E_commerce_product_catalog.Models;

namespace E_commerce_Product_Catalog.Service.Abstractions
{
    public interface ICategoryRepository
    {
        Task<Category> AddCategoryAsync(Category category);
        Task<List<Category>> GetCategoriesAsync();
        Task<Category?> GetCategoryByIdAsync(Guid id);
        Task UpdateCategoryAsync(Category category);
        Task RemoveCategoryAsync(Guid id);
    }
}