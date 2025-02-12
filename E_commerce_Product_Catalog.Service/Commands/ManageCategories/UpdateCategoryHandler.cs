using E_commerce_product_catalog.Abstraction;
using E_commerce_product_catalog.Models;
using MediatR;

namespace E_commerce_Product_Catalog.Service.Commands.ManageCategories
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, Category>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(request.Id);
            if (category == null)
                throw new CategoryNameNotFoundException(request.Id);

            category.CategoryName = request.NewCategoryName;

            await _categoryRepository.UpdateCategoryAsync(category);
            return category;
        }
    }

    public class CategoryNameNotFoundException : Exception
    {
        public CategoryNameNotFoundException(Guid requestId)
        {
            throw new NotImplementedException();
        }
    }
}