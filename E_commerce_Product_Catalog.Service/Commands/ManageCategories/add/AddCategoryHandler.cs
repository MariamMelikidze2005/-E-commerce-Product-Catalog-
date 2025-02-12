using E_commerce_product_catalog.Abstraction;
using E_commerce_product_catalog.Models;
using MediatR;

namespace E_commerce_Product_Catalog.Service.Commands.ManageCategories.add
{
    public class AddCategoryHandler : IRequestHandler<Commands.AddCategoryCommand, Category>
    {
        private readonly ICategoryRepository _categoryRepository;

        public AddCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> Handle(Commands.AddCategoryCommand request, CancellationToken cancellationToken)
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