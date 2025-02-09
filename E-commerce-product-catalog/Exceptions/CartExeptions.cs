namespace E_commerce_product_catalog.Exceptions
{
    public class CartIsEmptyExeptions : DomainExeption
    {
        public CartIsEmptyExeptions() 
            : base("Cart is empty")
        { }
    }
    public class InvalidQuantitiyOfCartItemExeption : DomainExeption
    {
        public InvalidQuantitiyOfCartItemExeption(Guid productId)
            : base("quantity must be positive")
        { }
    }



}
