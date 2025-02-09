namespace E_commerce_product_catalog.Models
{
    public class Cart
    {
        public Guid UserId { get; set; }    
        public List<CartItem> Items { get; set;} = new List<CartItem>();
    }
}
