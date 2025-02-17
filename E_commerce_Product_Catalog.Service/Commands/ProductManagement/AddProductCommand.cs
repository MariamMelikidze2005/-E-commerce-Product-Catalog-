using E_commerce_product_catalog.Models;
using MediatR;

namespace E_commerce_Product_Catalog.Service.Commands.ProductManagement
{
    public class AddProductCommand : IRequest<Product>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Guid CategoryId { get; set; }
        public Guid OwnerId { get; set; }

        public AddProductCommand(string name, string description, decimal price, int quantity, Guid categoryId, Guid ownerId)
        {
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
            CategoryId = categoryId;
            OwnerId = ownerId;
        }

        public (bool IsValid, List<string> Errors) Validate()
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(Name))
                errors.Add("Product name is required.");

            if (Price <= 0)
                errors.Add("Product price must be greater than zero.");

            if (Quantity < 0)
                errors.Add("Product quantity cannot be negative.");

            return (errors.Count == 0, errors);
        }
    }
}