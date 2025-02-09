namespace E_commerce_product_catalog.Exceptions
{
    public class OrderNotFoundException : DomainExeption
    {
        public OrderNotFoundException(Guid orderId)
            : base($"Order with ID '{orderId}' was not found.")
        {
        }
    }

    public class OrderCannotBeCancelledException : DomainExeption
    {
        public OrderCannotBeCancelledException()
            : base("Order cannot be cancelled, because It has already been confirmed or completed.")
        {
        }
    }

    public class OrderCannotBeConfirmedException : DomainExeption
    {
        public OrderCannotBeConfirmedException()
            : base("Order cannot be confirmed, because It must be in 'pending' status.")
        {
        }
    }

    public class OrderCannotBeCompletedException : DomainExeption
    {
        public OrderCannotBeCompletedException()
            : base("Order cannot be completed. It must be confirmed first.")
        {
        }
    }

    public class InsufficientStockException : DomainExeption
    {
        public InsufficientStockException()
            : base("There is not enough stock for the products in the order.")
        {
        }
    }
}
