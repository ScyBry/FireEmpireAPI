using Shared.DataTransferObjects.Projects;

namespace Service.Contracts;

public interface IProjectService
{
    Task<IEnumerable<ProjectDTO>> GetAllProjectsAsync(bool trackChanges);
    Task<ProjectDTO> GetProjectByIdAsync(Guid id, bool trackChanges);
    Task<ProjectDTO> CreateProjectAsync(ProjectForCreationDTO project);
    Task DeleteProjectAsync(Guid projectId, bool trackChanges);
}