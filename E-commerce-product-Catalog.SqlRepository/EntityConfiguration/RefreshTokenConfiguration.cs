using E_commerce.Identity.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_product_Catalog.SqlRepository.EntityConfiguration
{
    internal sealed class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(r => r.Value)
                .HasMaxLength(200);

            builder
                .HasIndex(r => r.Value)
                .IsUnique();

            builder
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);
        }
    }
}
