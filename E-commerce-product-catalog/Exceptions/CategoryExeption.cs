namespace E_commerce_product_catalog.Exceptions
{
    public class InvalidCAtegoryNameExeption : DomainExeption
    {
        public InvalidCAtegoryNameExeption()
            : base("Name must be between 1 and 100 characters")
        { }
    }

    public class CAtegoryNameNotFoundExeption : DomainExeption
    {
        public CAtegoryNameNotFoundExeption(Guid categoryId)
            : base($"Category name with this Id{categoryId}, not found")
        { }
    }
}
