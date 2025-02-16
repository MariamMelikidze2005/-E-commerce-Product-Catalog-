//using E_commerce_product_Catalog.SqlRepository.Database;

//namespace E_commerce_product_Catalog.SqlRepository.Imolementation
//{
//    internal sealed class TokenRepository : ITokenRepository
//    {
//        private readonly ApplicationDbContext _dbContext;

//        public TokenRepository(ApplicationDbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        public async Task SaveTokenAsync(Token token)
//        {
//            await _dbContext.Tokens.AddAsync(token);
//            await _dbContext.SaveChangesAsync();
//        }

//        public async Task<Token?> GetTokenByUserIdAsync(Guid userId)
//        {
//            return await _dbContext.Tokens
//                .FirstOrDefaultAsync(t => t.UserId == userId);
//        }

//        public async Task RevokeTokenAsync(Guid userId)
//        {
//            var token = await GetTokenByUserIdAsync(userId);
//            if (token != null)
//            {
//                _dbContext.Tokens.Remove(token);
//                await _dbContext.SaveChangesAsync();
//            }
//        }
//    }

   
//}