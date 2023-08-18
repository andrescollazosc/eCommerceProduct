using eCommerce.Products.Core.Products.Catalag.Models;

namespace eCommerce.Products.Core.Products.Catalag.Repositories;

public interface IProductDeviceRepository
{
    Task<ProductDevice> GetProductByIdAsync(int productId);
    Task<IEnumerable<ProductDevice>> GetAllAsync();
    Task<bool> AddAsync(ProductDevice productDevice);
    Task<bool> UpdateAsync(ProductDevice productDevice);
    Task<bool> DeleteAsync(int productId);
}

// TODO: Refactor in a future.
// CQRS
// metodos Add, Update, delete => Tocan directamente la base de datos.
// Method Get, No actualizan data pero retornan data.
