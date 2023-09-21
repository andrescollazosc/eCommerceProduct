using AutoMapper;
using eCommerce.Products.Api.DTO.Products;
using eCommerce.Products.Core.Products.Catalag.Models;

namespace eCommerce.Products.Api.Mappers;

public class ProductDeviceProfile : Profile
{
    public ProductDeviceProfile()
    {
        // Response Product
        CreateMap<ProductDevice, ProductDeviceResponseDTO>()
            .ForMember(dest => dest.Category, o => o.MapFrom(src => src.Category.ToString()))
            .ForMember(dest => dest.Status, o => o.MapFrom(src => src.Status.ToString()))
            .ForMember(dest => dest.BillingType, o => o.MapFrom(src => src.BillingType.ToString()))
            .ForPath(dest => dest.Details, o => o.MapFrom(src => new ProductDeviceDetialsDTO(src.Details.Brand, src.Details.Model, src.Details.Color, src.Details.Maker)));

        // Create Product
        CreateMap<CreateProductDeviceDTO, ProductDevice>()
            .ForMember(dest => dest.Category, o => o.MapFrom(src => src.Category.ToString()))
            .ForMember(dest => dest.Status, o => o.MapFrom(src => src.Status.ToString()))
            .ForMember(dest => dest.BillingType, o => o.MapFrom(src => src.BillingType.ToString()))
            .ForPath(dest => dest.Details, o => o.MapFrom(src => new ProductDeviceDetails(src.Details.Brand, src.Details.Model, src.Details.Color, src.Details.Maker)));

    }
}
