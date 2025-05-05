namespace Contracts;

public interface IRepositoryManager
{
    IProductRepository Product { get; }
    IProductCategoryRepository Category { get; }

    Task SaveAsync();
}