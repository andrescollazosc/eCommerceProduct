using eCommerce.Products.Core.Products.Catalag.Enums;
using eCommerce.Products.Core.Products.Catalag.Models;
using Microsoft.EntityFrameworkCore;


namespace eCommmerce.Product.Infrastructure;

internal class eCommerceProductDBContext : DbContext
{

    public eCommerceProductDBContext(DbContextOptions options) : base(options) { 
    
    }

    public DbSet<ProductDevice> product { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductDevice>().HasKey(product => product.Id);
        modelBuilder.Entity<ProductDevice>().Property(product => product.Name).IsRequired().HasMaxLength(60);
        modelBuilder.Entity<ProductDevice>().Property(product => product.Category).HasConversion<string>().IsRequired();
        modelBuilder.Entity<ProductDevice>().Property(product => product.Status).HasConversion<string>().IsRequired();
        modelBuilder.Entity<ProductDevice>().Property(product => product.BillingType).HasConversion<string>().IsRequired();
        modelBuilder.Entity<ProductDevice>().Property(product => product.CreatedBy).IsRequired().HasMaxLength(60);
        modelBuilder.Entity<ProductDevice>().Property(product => product.CreatedOn).IsRequired().HasMaxLength(60);
        modelBuilder.Entity<ProductDevice>().Property(product => product.UpdatedBy).IsRequired().HasMaxLength(60);
        
        var details = modelBuilder.Entity<ProductDevice>().OwnsOne(product => product.Details, detail => { 
            detail.Property(value => value.Maker).HasMaxLength(60).IsRequired();
            detail.Property(value => value.Brand).HasMaxLength(60).IsRequired();
            detail.Property(value => value.Color).HasMaxLength(60).IsRequired();
            detail.Property(value => value.Model).HasMaxLength(60).IsRequired();
        }); // cardinalidad

        details.Navigation(value => value.Details).IsRequired();

        // Constrains
        modelBuilder.Entity<ProductDevice>().HasCheckConstraint("ck_Product_Category", $"{nameof(Category)} IN ('{Category.VoicePlanProduct}',''{Category.DeviceTable}',''{Category.DeviceMobile}',''{Category.Other}')");
        modelBuilder.Entity<ProductDevice>().HasCheckConstraint("ck_Product_Status", $"{nameof(Status)} IN ('{Status.Active}', '{Status.Inactive}') ");
        modelBuilder.Entity<ProductDevice>().HasCheckConstraint("ck_Product_BillingType", $"{nameof(BillingType)} IN ('{BillingType.Recurring}', '{BillingType.OneTime}')");
    }

}
