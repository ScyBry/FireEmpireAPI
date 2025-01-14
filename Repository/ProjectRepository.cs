using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class ProjectRepository : RepositoryBase<Project>, IProjectRepository
{
    public ProjectRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Project>> GetAllProjectsAsync(bool trackChanges) =>
        await FindAll(trackChanges).OrderBy(c => c.Date).ToListAsync();


    public async Task<Project> GetProjectByIdAsync(Guid Id, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(Id), trackChanges).FirstOrDefaultAsync();

    public void CreateProject(Project project) => Create(project);
    public void DeleteProject(Project project) => Delete(project);
}