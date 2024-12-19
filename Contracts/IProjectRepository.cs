using Entities.Models;

namespace Contracts;

public interface IProjectRepository
{
    Task<IEnumerable<Project>> GetAllProjectsAsync(bool trackChanges);
    Task<Project> GetProjectByIdAsync(Guid id, bool trackChanges);
    void  CreateProject(Project project);
    void DeleteProject(Project project);
}