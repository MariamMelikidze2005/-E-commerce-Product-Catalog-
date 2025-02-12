using E_commerce_product_catalog.Abstraction;

namespace E_commerce_Product_Catalog.Service.Commands.CartManagement
{
    public class ClearCartCommand : ICommand
    {
        public int UserId { get; set; }

        public void Validate()
        {
            if (UserId <= 0)
            {
                throw new ArgumentException("Invalid User ID.");
            }
        }
    }
}
