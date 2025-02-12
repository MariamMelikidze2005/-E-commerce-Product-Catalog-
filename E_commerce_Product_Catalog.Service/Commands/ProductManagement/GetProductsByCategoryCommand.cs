using E_commerce_product_catalog.Models;
using MediatR;

namespace E_commerce_Product_Catalog.Service.Commands.ProductManagement
{
    public class GetProductsByCategoryCommand : IRequest<List<Product>>
    {
        public Guid CategoryId { get; set; }

        public GetProductsByCategoryCommand(Guid categoryId)
        {
            CategoryId = categoryId;
        }
    }
}