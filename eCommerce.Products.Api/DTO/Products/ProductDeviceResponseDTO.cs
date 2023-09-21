namespace eCommerce.Products.Api.DTO.Products
{
    public class ProductDeviceResponseDTO : ProductBaseDTO
    {
        public int Id { get; set; }
        public ProductDeviceDetialsDTO Details { get; set; }
    }
}
