using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace FIreEmpireAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IServiceManager _service;

        public CategoryController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _service.CategoryService.GetAllCategoriesAsync(trackChanges: false);
            return Ok(categories);
        }

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryForCreationDTO categoryForCreationDTO)
        {
            var category =
                await _service.CategoryService.CreateCategoryAsync(categoryForCreationDTO, trackChanges: false);
            return Ok(category);
        }
    }
}