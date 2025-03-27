namespace Contracts;

public interface IRepositoryManager
{
    ICategoryRepository CategoryRepository { get; }

    Task SaveAsync();
}