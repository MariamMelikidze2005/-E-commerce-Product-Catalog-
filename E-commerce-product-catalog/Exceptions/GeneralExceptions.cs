namespace E_commerce_product_catalog.Exceptions
{
    public class DatabaseExeption : DomainExeption
    {
        public DatabaseExeption()
            :base("Database error") 
        { }
    }

}
