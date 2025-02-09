namespace E_commerce_product_catalog.Models
{
    public class Category
    {
        public Category(string categoryName)
        {
            CategoryName = categoryName;
        }

        public Category()
        {
            throw new NotImplementedException();
        }

        public Guid  Id { get; set; }
        public string CategoryName { get; set; }
       
    }
}
