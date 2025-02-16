using E_commerce_product_catalog.Abstraction;
using E_commerce_product_catalog.Models;
using E_commerce_Product_Catalog.Service.Commands.ManageCategories;
using MediatR;

namespace E_commerce_Product_Catalog.Service.Commands.ManageCategories
{
    public class GetCategoriesHandler : IRequestHandler<GetCategoriesQuery, List<Category>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoriesHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetCategoriesAsync();
        }
    }
}