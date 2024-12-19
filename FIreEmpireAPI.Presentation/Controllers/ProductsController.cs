using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.Product;

namespace FIreEmpireAPI.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IServiceManager _service;

    public ProductsController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet("GetAllProducts")]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _service.ProductService.GetAllProductsAsync(false);
        return Ok(products);
    }

    [HttpGet("GetProductById/{id:guid}")]
    public async Task<IActionResult> GetProductById(Guid id)
    {
        var product = await _service.ProductService.GetProductByIdAsync(id, false);
        return Ok(product);
    }

    [HttpPost("CreateProduct", Name = "CreateProduct")]
    public async Task<IActionResult> CreateProduct([FromForm] ProductForCreationDTO product)
    {
        var createdProduct = await _service.ProductService.CreateProductAsync(product);
        return Ok(createdProduct);
    }

    [HttpDelete("DeleteProduct/{id:guid}", Name = "DeleteProduct")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        await _service.ProductService.DeleteProductAsync(id, false);
        return NoContent();
    }
}