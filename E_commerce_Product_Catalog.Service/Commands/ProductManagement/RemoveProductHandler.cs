using E_commerce_product_catalog.Abstraction.E_commerce_Product_Catalog.Service.Services.Abstractions;
using MediatR;

namespace E_commerce_Product_Catalog.Service.Commands.ProductManagement
{
    public class RemoveProductHandler : IRequestHandler<RemoveProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public RemoveProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            await _productRepository.RemoveProduct(request.ProductId);
        }
    }
}