using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_Product_Catalog.Service.Exceptions
{
    public class InvalidCAtegoryNameExeption : DomainExeption
    {
        public InvalidCAtegoryNameExeption()
            : base("Name must be between 1 and 100 characters")
        { }
    }

    public class CAtegoryNameNotFoundExeption : DomainExeption
    {
        public CAtegoryNameNotFoundExeption(Guid CategoryId)
            : base($"Category name with this Id{CategoryId}, not found")
        { }
    }
}
