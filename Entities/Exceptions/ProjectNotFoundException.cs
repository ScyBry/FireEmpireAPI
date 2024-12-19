namespace Entities.Exceptions;

public sealed class ProjectNotFoundException : NotFoundException
{
    public ProjectNotFoundException(Guid projectId) : base($"Project {projectId} was not found."){}
}