namespace E_commerce_product_catalog.Models
{
    public class Product
    {
        public Product(Guid id, string name, string description, Guid categoryId, decimal price, int quantity)
        {
            Id = id;
            Name = name;
            Description = description;
            CategoryId = categoryId;
            Price = price;
            Quantity = quantity;
        }

        public Product()
        {
            throw new NotImplementedException();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Guid OwnerId { get; set; } = Guid.Empty;

   
    }
}
