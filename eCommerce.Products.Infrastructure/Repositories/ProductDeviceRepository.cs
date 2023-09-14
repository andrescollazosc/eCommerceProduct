using eCommerce.Products.Core.Products.Catalag.Enums;
using eCommerce.Products.Core.Products.Catalag.Models;
using eCommerce.Products.Core.Products.Catalag.Repositories;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Products.Infrastructure.Repositories;

public class ProductDeviceRepository : IProductDeviceRepository
{
    private readonly ProductsDBContext _productsDBContext;

    public ProductDeviceRepository(ProductsDBContext productsDBContext)
    {
        _productsDBContext = productsDBContext;
    }

    public Task<bool> AddAsync(ProductDevice productDevice)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int productId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ProductDevice>> GetAllAsync()
    {
        var products = await _productsDBContext.Products.Where(product => product.Status == Status.Active).ToListAsync();
        
        return products;
    }

    public async Task<ProductDevice> GetProductByIdAsync(int productId)
    {
        var product = await _productsDBContext.Products.FindAsync(productId);

        return product;
    }

    public Task<bool> UpdateAsync(ProductDevice productDevice)
    {
        throw new NotImplementedException();
    }
}
