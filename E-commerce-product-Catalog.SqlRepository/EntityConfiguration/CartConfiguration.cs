using E_commerce_product_catalog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_commerce_product_Catalog.SqlRepository.EntityConfiguration;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.ToTable("Carts");

        builder.HasKey(c => c.UserId);

        builder.HasMany(c => c.Items)
            .WithOne()
            .HasForeignKey(ci => ci.ProductId)
            .IsRequired();
    }
}