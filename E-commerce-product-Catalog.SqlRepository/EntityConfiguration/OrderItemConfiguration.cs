using E_commerce_product_catalog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_commerce_product_Catalog.SqlRepository.EntityConfiguration;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("OrderItems");
        builder.Property(o => o.Price).HasColumnType("decimal(16,4)");

        builder.HasKey(oi => new { oi.ProductId, oi.Quantity });
    }
}