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
        Category AddCategory(Category category);
        List<Category> GetCategories();
        Category GetCategoryById(Guid id);
        void UpdateCategory(Category category);
        void RemoveCategory(Guid id);
    }
}
