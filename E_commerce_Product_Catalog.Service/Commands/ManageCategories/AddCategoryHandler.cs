using E_commerce_product_catalog.Models;
using E_commerce_Product_Catalog.Service.Abstractions;
using E_commerce_Product_Catalog.Service.Commands;
using MediatR;

namespace E_commerce_Product_Catalog.Service.Commands.ManageCategories
{
    public class AddCategoryHandler : IRequestHandler<AddCategoryCommand, Category>
    {
        private readonly ICategoryRepository _categoryRepository;

        public AddCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Id = Guid.NewGuid(),
                CategoryName = request.CategoryName
            };

            return await _categoryRepository.AddCategoryAsync(category);
        }
    }
}