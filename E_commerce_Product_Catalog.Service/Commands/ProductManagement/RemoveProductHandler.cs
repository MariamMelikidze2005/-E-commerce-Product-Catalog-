using E_commerce_Product_Catalog.Service.Abstractions;
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
            await _productRepository.RemoveProductAsync(request.ProductId);
        }
    }
}