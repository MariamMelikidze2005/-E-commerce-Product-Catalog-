namespace E_commerce_Product_Catalog.Service.Abstractions
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        public IProductRepository ProductRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public ICartRepository CartRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        //public ITokenRepository TokenRepository { get; }
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
        Task<int> SaveAsync();
    }
}