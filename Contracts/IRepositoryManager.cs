namespace Contracts;

public interface IRepositoryManager
{
    IProductRepository Product { get; }
    IProductCategoryRepository Category { get; }
    IContactRepository Contact { get; }

    Task SaveAsync();
}