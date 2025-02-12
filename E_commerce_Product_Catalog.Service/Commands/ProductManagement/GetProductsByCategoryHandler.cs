using E_commerce_product_catalog.Abstraction.E_commerce_Product_Catalog.Service.Services.Abstractions;
using E_commerce_product_catalog.Models;
using MediatR;

namespace E_commerce_Product_Catalog.Service.Commands.ProductManagement
{
    public class GetProductsByCategoryHandler : IRequestHandler<GetProductsByCategoryCommand, List<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsByCategoryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> Handle(GetProductsByCategoryCommand request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductsByCategory(request.CategoryId);
        }
    }
}