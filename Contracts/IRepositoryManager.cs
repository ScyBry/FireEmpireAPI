namespace Contracts;

public interface IRepositoryManager
{
    IProjectRepository Project { get; }
    IProductRepository Product { get; }

    Task SaveAsync();
}