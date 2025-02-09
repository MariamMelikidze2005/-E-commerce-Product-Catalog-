namespace E_commerce_product_catalog.Exceptions
{

    public class InvalidProductNameException : DomainExeption
    {
        public InvalidProductNameException()
            : base("Product name must be between 1 and 100 characters.")
        { }
    }
    public class InvalidProductPriceException : DomainExeption
    {
        public InvalidProductPriceException()
            : base("prduct price must be positive") 
        { }
    }



    public class ProductNotFoundException : DomainExeption
    {
        public ProductNotFoundException(Guid productId)
            : base($"Product with ID '{productId}' was not found.")
        {
        }
    }

    public class ProductNotInThisException : DomainExeption
    {
        public ProductNotInThisException()
            : base("No products available in the catalog.")
        {
        }
    }

    public class InvalidProductQuantityException : DomainExeption
    {
        public InvalidProductQuantityException()
            : base("product quantity mjust be positive")
        { }
    }

    public class ProductOutOfStockException : DomainExeption
    {
        public ProductOutOfStockException(Guid productId)
            : base("product with this Id is out of stock")
        { }
    }
    public class ProductAlreadyExistsException : DomainExeption
    {
        public ProductAlreadyExistsException(string name)
            : base($"product with this name :{name} is already in the cart")
        {}
    }

}
