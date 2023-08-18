using eCommerce.Products.Core.Products.Catalag.Models;

namespace eCommerce.Products.Core.Products.Catalag.Services;

public interface IProductDeviceService
{
    Task<ProductDevice> GetProductByIdAsync(int productId);
}
