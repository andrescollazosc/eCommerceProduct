using AutoMapper;
using eCommerce.Products.Api.DTO.Products;
using eCommerce.Products.Core.Common.Exceptions;
using eCommerce.Products.Core.Products.Catalag.Models;
using eCommerce.Products.Core.Products.Catalag.Services;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Products.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ProductController : Controller
{
    private readonly IProductDeviceService _productDeviceService;
    private readonly IMapper _mapper;

    public ProductController(IProductDeviceService productDeviceService,
        IMapper mapper)
    {
        _productDeviceService = productDeviceService;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ProductDeviceResponseDTO>> GetById(int id) {
        try
        {
            var product = await _productDeviceService.GetProductByIdAsync(id);

            return _mapper.Map<ProductDeviceResponseDTO>(product);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex) {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ProductDeviceResponseDTO>> Add([FromBody] CreateProductDeviceDTO createProductDeviceDTO)
    {
        try
        {
            var product = _mapper.Map<ProductDevice>(createProductDeviceDTO);

            await _productDeviceService.AddAsync(product);

            return _mapper.Map<ProductDeviceResponseDTO>(product);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductDeviceResponseDTO>> Put([FromBody] UpdateProductDeviceDTO updateProductDeviceDTO)
    {
        try
        {
            var updateProduct = _mapper.Map<ProductDevice>(updateProductDeviceDTO);

            await _productDeviceService.UpdateAsync(updateProduct);

            return _mapper.Map<ProductDeviceResponseDTO>(updateProduct);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<ProductDeviceResponseDTO>>> GetAll()
    {
        try
        {
            
            var products = await _productDeviceService.GetAllAsync();

           return products.Select(productVal => _mapper.Map<ProductDeviceResponseDTO>(productVal)).ToList();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

}
