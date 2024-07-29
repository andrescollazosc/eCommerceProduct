using eCommerce.Products.Core.Products.Catalag.Models;
using eCommerce.Products.Core.Products.Catalag.Repositories;
using eCommerce.Products.Core.Products.Catalag.Services;
using eCommerce.Products.Core.Products.Catalag.Services.Impl;
using eCommerce.Products.Core.Products.Catalag.Validators;
using eCommerce.Products.Infrastructure.Repositories;
using FluentValidation;

namespace eCommerce.Products.Api.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static void RegisterDependencies(this IServiceCollection services) {
            services.AddScoped<IProductDeviceRepository, ProductDeviceRepository>();
            services.AddScoped<IProductDeviceService, ProductDeviceService>();

            services.AddSingleton<IValidator<ProductDevice>, ProductDeviceValidator>();
        }
    }
}
