

namespace E_commerce_Product_Catalog.Service.Exceptions
{
    public class DomainExeption : Exception
    {
        public DomainExeption()
        {
            
        }

        public DomainExeption(string message)
            : base(message)
        {
            
        }

        public DomainExeption(string message, Exception innerException)
            : base(message, innerException) 
        {
            
        }
    }
}
