using eCommerce.Products.Core.Products.Catalag.Models;

namespace eCommerce.Products.Core.Products.Catalag.Services;

public interface IProductDeviceService
{
    Task<ProductDevice> GetProductByIdAsync(int productId);
    Task<bool> AddAsync(ProductDevice product);
    Task<bool> UpdateAsync(ProductDevice product);
    Task<IEnumerable<ProductDevice>> GetAllAsync();
}
