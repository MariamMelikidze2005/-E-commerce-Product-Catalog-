using E_commerce_product_catalog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_commerce_product_Catalog.SqlRepository.EntityConfiguration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");

        builder.HasKey(o => o.Id);
        builder.Property(o => o.TotalPrice).HasColumnType("decimal(16,4)");

        builder.HasMany(o => o.Items)
            .WithOne()
            .HasForeignKey(oi => oi.ProductId)
            .IsRequired();
    }
}