using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects.Projects;

namespace Service;

internal sealed class ProjectService : IProjectService
{
    private readonly IFileService _fileService;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repository;

    public ProjectService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper,
        IFileService fileService)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
        _fileService = fileService;
    }

    public async Task<IEnumerable<ProjectDTO>> GetAllProjectsAsync(bool trackChanges)
    {
        var projects = await _repository.Project.GetAllProjectsAsync(false);
        var projectsToReturn = _mapper.Map<IEnumerable<ProjectDTO>>(projects);
        return projectsToReturn;
    }

    public async Task<ProjectDTO> GetProjectByIdAsync(Guid id, bool trackChanges)
    {
        var project = await GetProjectAndCheckIfItExists(id, trackChanges);
        var projectToReturn = _mapper.Map<ProjectDTO>(project);
        return projectToReturn;
    }


    public async Task<ProjectDTO> CreateProjectAsync(ProjectForCreationDTO project)
    {
        var projectEntity = _mapper.Map<Project>(project);

        var imagesPath = await _fileService.SaveFilesAsync(project.Images, project.Name);
        projectEntity.ImagesPath = imagesPath;

        _repository.Project.CreateProject(projectEntity);
        await _repository.SaveAsync();

        var projectToReturn = _mapper.Map<ProjectDTO>(projectEntity);
        return projectToReturn;
    }

    public async Task DeleteProjectAsync(Guid projectId, bool trackChanges)
    {
        var project = await GetProjectAndCheckIfItExists(projectId, trackChanges);

        _repository.Project.DeleteProject(project);
        await _repository.SaveAsync();

        var projectDirectory = Path.Combine("Uploads", project.Name);
        if (Directory.Exists(projectDirectory)) Directory.Delete(projectDirectory, true);
    }

    private async Task<Project> GetProjectAndCheckIfItExists(Guid id, bool trackChanges)
    {
        var project = await _repository.Project.GetProjectByIdAsync(id, trackChanges);
        if (_repository is null) throw new ProjectNotFoundException(id);

        return project;
    }
}