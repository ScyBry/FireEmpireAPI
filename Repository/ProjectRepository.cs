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
        FindByCondition(c => c.Id.Equals(Id), trackChanges).SingleOrDefault();

    public  void CreateProject(Project project) => Create(project);
    public void DeleteProject(Project project) => Delete(project);
}