using E_commerce_product_catalog.Abstraction;
using MediatR;
using ICategoryRepository = E_commerce_Product_Catalog.Service.Services.Abstractions.ICategoryRepository;

namespace E_commerce_Product_Catalog.Service.Commands.ManageCategories
{
    public class RemoveCategoryHandler : IRequestHandler<RemoveCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public RemoveCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(request.Id);
            if (category == null)
                throw new CategoryNameNotFoundException(request.Id);

            await _categoryRepository.RemoveCategoryAsync(request.Id);
        }
    }
}