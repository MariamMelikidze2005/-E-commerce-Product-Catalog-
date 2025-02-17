using E_commerce_product_catalog.Models;
using E_commerce_Product_Catalog.Service.Abstractions;
using FluentValidation;
using MediatR;

namespace E_commerce_Product_Catalog.Service.Commands.ProductManagement
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        private readonly IValidator<Product> _validator;

        public AddProductHandler(IProductRepository productRepository, IValidator<Product> validator)
        {
            _productRepository = productRepository;
            _validator = validator;
        }

        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
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

            // ვალიდაცია
            var validationResult = _validator.Validate(product);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ArgumentException($"Validation failed: {errors}");
            }

            return await _productRepository.AddProductAsync(product);
        }
    }
}