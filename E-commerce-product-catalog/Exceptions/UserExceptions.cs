namespace E_commerce_product_catalog.Exceptions
{
    public class UserAlreadyExistsDomainExeption : DomainExeption
    {
        public UserAlreadyExistsDomainExeption(string email)
            : base($"A user with the email '{email}' already exists.")
        {
        }
    }

    public class InvalidEmailFormatDomainExeption : DomainExeption
    {
        public InvalidEmailFormatDomainExeption(string email)
            : base($"The email '{email}' is in an invalid format.")
        {
        }
    }

    public class InvalidPasswordDomainExeption : DomainExeption
    {
        public InvalidPasswordDomainExeption()
            : base("Password must be between 8 and 16 characters.")
        {
        }
    }

    public class InvalidNameDomainExeption : DomainExeption
    {
        public InvalidNameDomainExeption()
            : base("Name must be between 1 and 100 characters.")
        {
        }
    }


    public class UserNotFoundDomainExeption : DomainExeption
    {
        public UserNotFoundDomainExeption(Guid UserId)
            : base($"User with this Id{UserId} not found")
        {
        }
    }
}
