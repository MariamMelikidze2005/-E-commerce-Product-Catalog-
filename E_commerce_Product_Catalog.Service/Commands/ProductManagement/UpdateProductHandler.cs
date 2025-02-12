using E_commerce_product_catalog.Abstraction.E_commerce_Product_Catalog.Service.Services.Abstractions;
using MediatR;

namespace E_commerce_Product_Catalog.Service.Commands.ProductManagement
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductByIdAsync(request.ProductId);
            if (product == null)
            {
                throw new ArgumentException("Product not found.");
            }

            product.Name = request.Name ?? product.Name;
            product.Description = request.Description ?? product.Description;
            product.Price = request.Price ?? product.Price;
            product.Quantity = request.Quantity ?? product.Quantity;
            product.CategoryId = request.CategoryId ?? product.CategoryId;

            await _productRepository.UpdateProduct(product);
        }
    }
}