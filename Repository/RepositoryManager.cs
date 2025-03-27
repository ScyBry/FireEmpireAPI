using Contracts;

namespace Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly Lazy<IProductRepository> _productRepository;
    private readonly Lazy<ICategoryRepository> _categoryRepository;

    private readonly RepositoryContext _repositoryContext;


    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;

        _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(_repositoryContext));
        _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(_repositoryContext));
    }


    public async Task SaveAsync()
    {
        await _repositoryContext.SaveChangesAsync();
    }


    public void Save()
    {
        _repositoryContext.SaveChanges();
    }
}