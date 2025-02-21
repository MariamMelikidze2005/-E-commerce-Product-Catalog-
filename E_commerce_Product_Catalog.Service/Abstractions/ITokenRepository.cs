using E_commerce_product_catalog.Models;

namespace E_commerce_Product_Catalog.Service.Abstractions
{
    public interface ITokenRepository
    {
        Task SaveTokenAsync(Token token);
        Task<Token?> GetTokenByUserIdAsync(Guid userId);
        Task RevokeTokenAsync(Guid userId);
    }

    public class Token
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public string TokenValue { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }

        public User? User { get; set; } // ნავიგაციისთვის
    }
}