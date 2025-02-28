using E_commerce_product_catalog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_commerce.Identity.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;

namespace E_commerce_product_Catalog.SqlRepository.EntityConfiguration
{
    public sealed class ApplicationRoleSeedConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder.HasData(
            new ApplicationRole
            {
                Id = "1",
                Name = "Customer",
                NormalizedName = "CUSTOMER"
            },
            new ApplicationRole
            {
                Id = "2",
                Name = "Manager",
                NormalizedName = "MANAGER"
            },
            new ApplicationRole
                {
                Id = "3",
                Name = "Owner",
                NormalizedName = "OWNER"
            }
            );

        }
    }

    internal sealed class ApplicationUserSeed : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(new ApplicationUser
            {
                Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                UserName = "EcommerceDefaultOwner",
                Email = "ECommerceOwner@yopmail.com",
                EmailConfirmed = true,
                LockoutEnabled = true,
                NormalizedEmail = "EVENTMANAGEROWNER@YOPMAIL.COM",
                NormalizedUserName = "SERVICEDEFAULTOWNER",
                //"!PasswordOwner!123!"
                PasswordHash = "AQAAAAIAAYagAAAAEGIOE+75U/gx0OdCzYPi19fYQZUZao7vshDU74orMUYLNSgWOuYq0uGUzi9IyKbATQ=="
            });

        }
    }
    internal sealed class ApplicationUserRoles : IEntityTypeConfiguration<IdentityUserRole<string>>
    {

        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "3",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                });
        }
    }
}
