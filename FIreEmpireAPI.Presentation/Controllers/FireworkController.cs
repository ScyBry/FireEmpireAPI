using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            await _service.
        }


    }
}
