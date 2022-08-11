using AloeExpress.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AloeExpress.ViewModels.ProductType;
using AloeExpress.ViewModels.Recipient;
using AloeExpress.ViewModels.Order;

namespace AloeExpress.Data
{
    public class ApplicationDbContext : IdentityDbContext<Provider>
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Provider> Providers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Recipient> Recipients { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var recipientBuilder = builder.Entity<Recipient>();
            recipientBuilder.HasIndex(x => x.FullName).IsUnique();
            recipientBuilder.Property(x => x.FullName).IsRequired();

            var orderBuilder = builder.Entity<Order>();
            orderBuilder.Property(x => x.RecipientId).IsRequired();
            orderBuilder.HasIndex(x => x.Id).IsUnique();

            var productTypeBuilder = builder.Entity<ProductType>();
            productTypeBuilder.HasIndex(x => x.Name).IsUnique();

        }
        public DbSet<AloeExpress.ViewModels.ProductType.ProductTypeViewModel> ProductTypeViewModel { get; set; }
        public DbSet<AloeExpress.ViewModels.Recipient.RecipientViewModel> RecipientViewModel { get; set; }
        public DbSet<AloeExpress.ViewModels.Order.OrderViewModel> OrderViewModel { get; set; }
    }
}
