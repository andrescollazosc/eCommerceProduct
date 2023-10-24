using eCommerce.Products.Core.Common.Exceptions;
using eCommerce.Products.Core.Products.Catalag.Models;
using eCommerce.Products.Core.Products.Catalag.Repositories;
using FluentValidation;

namespace eCommerce.Products.Core.Products.Catalag.Services.Impl;

public class ProductDeviceService : IProductDeviceService
{
    private readonly IProductDeviceRepository _productDeviceRepository;
    private readonly IValidator<ProductDevice> _validator;

    public ProductDeviceService(IProductDeviceRepository productDeviceRepository, IValidator<ProductDevice> validator)
    {
        _productDeviceRepository = productDeviceRepository;
        _validator = validator;
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

        var validation = await _validator.ValidateAsync(product);

        if (!validation.IsValid)
            throw new ValidationException(validation.Errors);

        return await _productDeviceRepository.AddAsync(product);
    }

    public async Task<bool> UpdateAsync(ProductDevice product)
    {
        product.UpdatedOn = DateTime.UtcNow;
        product.UpdatedBy = "Default";

        return await _productDeviceRepository.UpdateAsync(product);
    }

    public async Task<IEnumerable<ProductDevice>> GetAllAsync()
    {
        return await _productDeviceRepository.GetAllAsync();
    }

}
