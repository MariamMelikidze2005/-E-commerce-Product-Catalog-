using MediatR;

namespace E_commerce_Product_Catalog.Service.Commands.ProductManagement
{
    public class UpdateProductCommand : IRequest
    {
        public Guid ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public Guid? CategoryId { get; set; }

        public UpdateProductCommand(Guid productId, string? name, string? description, decimal? price, int? quantity, Guid? categoryId)
        {
            ProductId = productId;
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
            CategoryId = categoryId;
        }
    }
}