using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.Projects;

namespace FIreEmpireAPI.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectsController : ControllerBase
{
    private readonly IServiceManager _service;

    public ProjectsController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet("GetAllProjects")]
    public async Task<IActionResult> GetProjects()
    {
        var projects = await _service.ProjectService.GetAllProjectsAsync(false);
        return Ok(projects);
    }

    [HttpGet("GetProjectById/{id:guid}")]
    public async Task<IActionResult> GetProjectById(Guid id)
    {
        var project = await _service.ProjectService.GetProjectByIdAsync(id, false);
        return Ok(project);
    }

    [HttpPost("CreateProject", Name = "CreateProject")]
    public async Task<IActionResult> CreateProject([FromForm] ProjectForCreationDTO project)
    {
        var createdProject = await _service.ProjectService.CreateProjectAsync(project);
        return Ok(createdProject);
    }

    [HttpDelete("DeleteProject/{id:guid}", Name = "DeleteProject")]
    public async Task<IActionResult> DeleteProject(Guid id)
    {
        await _service.ProjectService.DeleteProjectAsync(id, false);
        return NoContent();
    }
}