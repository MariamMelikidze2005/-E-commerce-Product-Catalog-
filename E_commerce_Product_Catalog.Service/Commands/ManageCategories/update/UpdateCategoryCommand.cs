using E_commerce_product_catalog.Models;
using MediatR;

namespace E_commerce_Product_Catalog.Service.Commands.ManageCategories.update
{
    public class UpdateCategoryCommand : IRequest<Category>
    {
        public Guid Id { get; set; }
        public string NewCategoryName { get; set; }

        public UpdateCategoryCommand(Guid id, string newCategoryName)
        {
            Id = id;
            NewCategoryName = newCategoryName;
        }
    }
}