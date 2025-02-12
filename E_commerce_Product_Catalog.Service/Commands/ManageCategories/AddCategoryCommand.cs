using E_commerce_product_catalog.Models;
using MediatR;

namespace E_commerce_Product_Catalog.Service.Commands.ManageCategories
{
    public class AddCategoryCommand : IRequest<Category>
    {
        public string CategoryName { get; set; }

        public AddCategoryCommand(string categoryName)
        {
            CategoryName = categoryName;
        }
    }
}