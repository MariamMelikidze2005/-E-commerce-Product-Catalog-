using E_commerce_Product_Catalog.Service.Commands.ManageCategories.update;
using MediatR;
using ICategoryRepository = E_commerce_Product_Catalog.Service.Abstractions.ICategoryRepository;

namespace E_commerce_Product_Catalog.Service.Commands.ManageCategories.remove
{
    public class RemoveCategoryHandler : IRequestHandler<RemoveCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public RemoveCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(request.Id);
            if (category == null)
                throw new CategoryNameNotFoundException(request.Id);

            await _categoryRepository.RemoveCategoryAsync(request.Id);
            return default;
        }
    }
}