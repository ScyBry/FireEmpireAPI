using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.Mail;

namespace FIreEmpireAPI.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmailController : ControllerBase
{
    private readonly IServiceManager _service;

    public EmailController(IServiceManager service)
    {
        _service = service;
    }

    [HttpPost("send-email")]
    public async Task<IActionResult> SendEmail([FromBody] MailDTO mailDto)
    {
        await _service.EmailService.SendFeedbackEmailAsync(mailDto);
        return Ok("Email sent successfully.");
    }
}