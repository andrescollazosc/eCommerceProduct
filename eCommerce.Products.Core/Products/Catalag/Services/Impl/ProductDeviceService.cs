using eCommerce.Products.Core.Common.Exceptions;
using eCommerce.Products.Core.Products.Catalag.Models;
using eCommerce.Products.Core.Products.Catalag.Repositories;

namespace eCommerce.Products.Core.Products.Catalag.Services.Impl;

public class ProductDeviceService : IProductDeviceService
{
    private readonly IProductDeviceRepository _productDeviceRepository;

    public ProductDeviceService(IProductDeviceRepository productDeviceRepository)
    {
        _productDeviceRepository = productDeviceRepository;
    }

    public async Task<ProductDevice> GetProductByIdAsync(int productId)
    {
        var product = await _productDeviceRepository.GetProductByIdAsync(productId);

        if (product is null)
            throw new NotFoundException($"The product Id { productId } was not found.");

        return product;
    }

    public async Task<bool> AddAsync(ProductDevice product)
    {
        product.CreatedOn = DateTime.UtcNow;
        product.CreatedBy = "Default";

        return await _productDeviceRepository.AddAsync(product);
    }

    public async Task<bool> UpdateAsync(ProductDevice product)
    {
        product.UpdatedOn = DateTime.UtcNow;
        product.UpdatedBy = "Default";

        return await _productDeviceRepository.UpdateAsync(product);
    }
}
