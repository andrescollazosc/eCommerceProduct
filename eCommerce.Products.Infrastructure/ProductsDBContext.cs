using eCommerce.Products.Core.Products.Catalag.Enums;
using eCommerce.Products.Core.Products.Catalag.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Products.Infrastructure;

public class ProductsDBContext : DbContext
{
    public ProductsDBContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<ProductDevice> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductDevice>().HasKey(product => product.Id);
        modelBuilder.Entity<ProductDevice>().Property(product => product.Name).IsRequired().HasMaxLength(60);
        modelBuilder.Entity<ProductDevice>().Property(product => product.Category).HasConversion<string>().IsRequired();
        modelBuilder.Entity<ProductDevice>().Property(product => product.Status).HasConversion<string>().IsRequired();
        modelBuilder.Entity<ProductDevice>().Property(product => product.BillingType).HasConversion<string>().IsRequired();
        modelBuilder.Entity<ProductDevice>().Property(product => product.CreatedBy).IsRequired().HasMaxLength(60);
        modelBuilder.Entity<ProductDevice>().Property(product => product.CreatedOn).IsRequired();
        modelBuilder.Entity<ProductDevice>().Property(product => product.UpdatedBy).HasMaxLength(60);
        var details = modelBuilder.Entity<ProductDevice>().OwnsOne(product => product.Details, detail => {
            detail.Property(x=>x.Maker).HasMaxLength(60).IsRequired();
            detail.Property(x => x.Brand).HasMaxLength(60).IsRequired();
            detail.Property(x => x.Color).HasMaxLength(60).IsRequired();
            detail.Property(x => x.Model).HasMaxLength(60).IsRequired();
        });
        details.Navigation(x => x.Details).IsRequired();

        //Constraints
        modelBuilder.Entity<ProductDevice>().HasCheckConstraint("Ck_Product_Category", $"{nameof(Category)} IN ('{Category.VoicePlanProduct}', '{Category.DeviceMobile}', '{Category.DeviceTable}','{Category.Other}')");
        modelBuilder.Entity<ProductDevice>().HasCheckConstraint("Ck_Product_Status", $"{nameof(Status)} IN ('{Status.Active}', '{Status.Inactive}')");
        modelBuilder.Entity<ProductDevice>().HasCheckConstraint("Ck_Product_BillingType", $"{nameof(BillingType)} IN ('{BillingType.Recurring}', '{BillingType.OneTime}')");
    }
}
