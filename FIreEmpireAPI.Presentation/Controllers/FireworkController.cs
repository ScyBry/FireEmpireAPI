using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace FIreEmpireAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FireworkController : ControllerBase
    {
        private readonly IServiceManager _service;

        public FireworkController(IServiceManager service)
        {
            _service = service;
        }


        [HttpPost("ImportFromExcel")]
        public async Task<IActionResult> ImportFromExcel(IFormFile file)
        {
            await _service.FireworksService.ImportFireworksFromExcelAsync(file);
            return Ok();
        }


        [HttpGet("ExportToExcel")]
        public async Task<IActionResult> ExportToExcel()
        {
            {
                var excelData = await _service.FireworksService.ExportFireworksToExcelAsync();
                return File(excelData, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "fireworks.xlsx");
            }

        }


        [HttpPost("Create")]
        public async Task<IActionResult> Create(FireworkForCreationDTO firework)
        {
            var fireworkForReturn = await _service.FireworksService.CreateFirework(firework, false);
            return Ok(fireworkForReturn);

        }


        [HttpPost("Delete/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.FireworksService.DeleteFirework(id);
            return Ok();
        }
    }
}
