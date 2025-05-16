using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace FIreEmpireAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;


        public CategoryController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }


        [HttpGet]
        public async Task<IActionResult> GetCategories([FromQuery] CategoryParameters parameters)
        {
            var categories = await _serviceManager.CategoryService.GetCategoriesAsync(parameters, false);
            return Ok(categories);
        }


        [HttpGet("{id:guid}", Name = "GetCategoryById")]
        public async Task<IActionResult> GetCategoryById(Guid id, [FromQuery] bool includeProducts = false)
        {
            var category = await _serviceManager.CategoryService.GetCategoryAsync(id, includeProducts);
            return Ok(category);
        }

        [HttpGet("category/{categoryId:guid}")]
        public async Task<IActionResult> GetCategoryByCategoryId(Guid categoryId,
            [FromQuery] bool includeProducts = false)
        {
            var category =
                await _serviceManager.CategoryService.GetCategoryAsync(categoryId, trackChanges: false,
                    includeProducts);

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryForCreationDto category)
        {
            if (category is null)
                return BadRequest("CategoryForCreationDto object is null");

            var createdCategory = await _serviceManager.CategoryService.CreateCategoryAsync(category);
            return CreatedAtRoute("CategoryById", new { id = createdCategory.Id }, createdCategory);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateCategory(Guid id, [FromBody] ProductCategoryForUpdateDto category)
        {
            if (category is null)
                return BadRequest("ProductCategoryForUpdateDto object is null");

            await _serviceManager.CategoryService.UpdateCategoryAsync(id, category, true);
            return NoContent();
        }


        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            await _serviceManager.CategoryService.DeleteCategoryAsync(id, false);
            return NoContent();
        }
    }
}