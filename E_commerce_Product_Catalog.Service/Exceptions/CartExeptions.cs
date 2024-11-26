using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_Product_Catalog.Service.Exceptions
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
