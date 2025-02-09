using E_commerce_product_catalog.Models;
using Microsoft.EntityFrameworkCore;

//using E_commerce_Product_Catalog.Service.Models;

namespace E_commerce_product_Catalog.SqlRepository.Database
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.Items)
                .WithOne()
                .HasForeignKey(oi => oi.ProductId)
                .IsRequired();

            modelBuilder.Entity<OrderItem>()
                .HasKey(oi => new { oi.ProductId, oi.Quantity });

            modelBuilder.Entity<Product>()
                .HasOne<Category>()
                .WithMany()
                .HasForeignKey(p => p.CategoryId)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(p => p.OwnerId)
                .IsRequired();

            modelBuilder.Entity<Cart>()
                .HasMany(c => c.Items)
                .WithOne()
                .HasForeignKey(ci => ci.ProductId)
                .IsRequired();

            modelBuilder.Entity<CartItem>()
                .HasKey(ci => new { ci.ProductId, ci.Quantity });


        }
    }
}
