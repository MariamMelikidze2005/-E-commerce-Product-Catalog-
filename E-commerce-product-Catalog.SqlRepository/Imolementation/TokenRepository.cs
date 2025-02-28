using E_commerce_product_Catalog.SqlRepository.Database;
using E_commerce.Identity.Models;
using E_commerce.Identity.Service.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_product_Catalog.SqlRepository.Imolementation
{
    internal sealed class TokenRepository : ITokenRepository
    {
        private readonly ApplicationDbContext _databaseContext;

        public TokenRepository(ApplicationDbContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<RefreshToken?> GetRefreshTokenAsync(string token)
        {
            return await _databaseContext
                .RefreshTokens
                .FirstOrDefaultAsync(x => x.Value == token);
        }

        public async Task DeleteRefreshTokenAsync(Guid id)
        {
            await _databaseContext
                .RefreshTokens
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task AddRefreshTokenAsync(RefreshToken refreshToken)
        {
            await _databaseContext.RefreshTokens.AddAsync(refreshToken);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(RefreshToken refreshToken)
        {
            _databaseContext.RefreshTokens.Update(refreshToken);
            await _databaseContext.SaveChangesAsync();
        }
    }
}