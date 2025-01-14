namespace Contracts;

public interface IRepositoryManager
{
    IProjectRepository Project { get; }
    IProductRepository Product { get; }
    IFireworkRepository Firework { get; }

    Task SaveAsync();
}