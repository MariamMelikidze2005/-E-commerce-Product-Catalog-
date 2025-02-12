using E_commerce_product_catalog.Abstraction.E_commerce_Product_Catalog.Service.Services.Abstractions;
using E_commerce_product_catalog.Models;
using MediatR;

namespace E_commerce_Product_Catalog.Service.Commands.ProductManagement
{
    public class AddProductHandler : IRequestHandler<Commands.AddProductCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        private readonly AddProductCommandValidator _validator;

        public AddProductHandler(IProductRepository productRepository, AddProductCommandValidator validator)
        {
            _productRepository = productRepository;
            _validator = validator;
        }

        public async Task<Product> Handle(Commands.AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Quantity = request.Quantity,
                CategoryId = request.CategoryId,
                OwnerId = request.OwnerId
            };

            var validationResult = _validator.Validate(product);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ArgumentException($"Validation failed: {errors}");
            }

            return await _productRepository.AddProduct(product);
        }
    }
}