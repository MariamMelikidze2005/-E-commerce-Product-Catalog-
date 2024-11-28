using E_commerce_Product_Catalog.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_Product_Catalog.Service.Services.Abstractions
{
    public interface ICategoryRepository
    {
        Task<Category> AddCategoryAsync(Category category);
        Task<List<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(Guid id);
        Task UpdateCategoryAsync(Category category);
        Task RemoveCategoryAsync(Guid id);
    }


}
