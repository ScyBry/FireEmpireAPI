using AutoMapper;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.RequestFeatures;
using Shared.DataTransferObjects;

namespace FIreEmpireAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;


        public ProductController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery] ProductParameters parameters)
        {
            var (products, metaData) =
                await _serviceManager.ProductService.GetAllProductsAsync(parameters, trackChanges: false);

            return Ok(products);
        }

        [HttpGet("{id:guid}", Name = "GetProductById")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var product = await _serviceManager.ProductService.GetProductAsync(id, false);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductForCreationDto product)
        {
            if (product is null)
                return BadRequest("Object is null");

            var createdProduct = await _serviceManager.ProductService.CreateProductAsync(product);

            return CreatedAtRoute("GetProductById", new { id = createdProduct.Id }, createdProduct);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] ProductForUpdateDto product)
        {
            if (product is null)
                return BadRequest("Object is null");


            await _serviceManager.ProductService.UpdateProductAsync(id, product, true);
            return NoContent();
        }


        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await _serviceManager.ProductService.DeleteProductAsync(id, false);
            return NoContent();
        }

        [HttpGet("category/{categoryId:guid}")]
        public async Task<IActionResult> GetProductsByCategory(Guid categoryId,
            [FromQuery] ProductParameters parameters)
        {
            var products =
                await _serviceManager.ProductService.GetProductsByCategoryAsync(categoryId, parameters, false);
            return Ok(products);
        }
    }
}