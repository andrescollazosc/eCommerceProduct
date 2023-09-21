using eCommerce.Products.Core.Products.Catalag.Enums;
using eCommerce.Products.Core.Products.Catalag.Models;
using eCommerce.Products.Core.Products.Catalag.Repositories;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Products.Infrastructure.Repositories;

public class ProductDeviceRepository : IProductDeviceRepository
{
    private readonly ProductsDBContext _productsDBContext;

    public ProductDeviceRepository(ProductsDBContext productsDBContext)
    {
        _productsDBContext = productsDBContext;
    }

    public async Task<bool> AddAsync(ProductDevice productDevice)
    {
        await _productsDBContext.Products.AddAsync(productDevice);
        var result = await _productsDBContext.SaveChangesAsync();

        return result > 0;
    }

    public Task<bool> DeleteAsync(int productId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ProductDevice>> GetAllAsync()
    {
        // SELECT * FROM Products WHERE Status = "Active"
        var products = await _productsDBContext.Products.Where(product => product.Status == Status.Active).ToListAsync();
        
        return products;
    }

    public async Task<ProductDevice> GetProductByIdAsync(int productId)
    {
        var product = await _productsDBContext.Products.FindAsync(productId);

        return product;
    }

    public async Task<bool> UpdateAsync(ProductDevice productDevice)
    {
        var product = await GetProductByIdAsync(productDevice.Id);

        product.Status = productDevice.Status;
        product.UpdatedBy = productDevice.UpdatedBy;
        product.UpdatedOn = productDevice.UpdatedOn;
        product.Category = productDevice.Category;
        product.BillingType = productDevice.BillingType;
        product.Name = productDevice.Name;
        product.Details = productDevice.Details;

        var result = await _productsDBContext.SaveChangesAsync();
        
        return result > 0;
    }
}
