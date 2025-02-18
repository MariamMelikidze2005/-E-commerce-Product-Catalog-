using E_commerce_Product_Catalog.Service.Abstractions;
using E_commerce_product_Catalog.SqlRepository.Database;
using E_commerce_product_Catalog.SqlRepository.Imolementation;

namespace E_commerce_product_Catalog.SqlRepository.UnitofWork
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        #region Private Fields
        private IUserRepository _userRepository;
        private IProductRepository _productRepository;
        private IOrderRepository _orderRepository;
        private ICartRepository _cartRepository;
        private ICategoryRepository _categoryRepository;
        //private ITokenRepository _tokenRepository;
        private IUnitOfWork _unitOfWorkImplementation;

        #endregion

        public UnitOfWork(ApplicationDbContext dbContext, IUserRepository userRepository, IProductRepository productRepository, IOrderRepository orderRepository, ICartRepository cartRepository, ICategoryRepository categoryRepository)
        {
            _dbContext = dbContext;
            UserRepository = userRepository;
            ProductRepository = productRepository;
            OrderRepository = orderRepository;
            CartRepository = cartRepository;
            CategoryRepository = categoryRepository;
            _userRepository = userRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;
            _categoryRepository = categoryRepository;
        }

        #region Public Properties
        public IUserRepository Users => _userRepository ??= new UserRepository(_dbContext);
        public IProductRepository Products => _productRepository ??= new ProductRepository(_dbContext);
        public IOrderRepository Orders => _orderRepository ??= new OrderRepository(_dbContext);
        public ICartRepository Carts => _cartRepository ??= new CartRepository(_dbContext);
        public ICategoryRepository Categories => _categoryRepository ??= new CategoryRepository(_dbContext);
        //public ITokenRepository Tokens => _tokenRepository ??= new TokenRepository(_dbContext);
        #endregion

        #region Methods

        public IUserRepository UserRepository { get; }
        public IProductRepository ProductRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public ICartRepository CartRepository { get; }
        public ICategoryRepository CategoryRepository { get; }


        //public ITokenRepository TokenRepository => _unitOfWorkImplementation.TokenRepository;

        //public ITokenRepository TokenRepository { get; }
        public Task BeginTransactionAsync() => _dbContext.Database.BeginTransactionAsync();
        public Task CommitAsync() => _dbContext.Database.CommitTransactionAsync();
        public Task RollbackAsync() => _dbContext.Database.RollbackTransactionAsync();
        public Task<int> SaveAsync() => _dbContext.SaveChangesAsync();

        public void Dispose()
        {
            _dbContext.Dispose();
        }
        #endregion
    }
}
