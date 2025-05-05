using Contracts;

namespace Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly Lazy<IProductRepository> _productRepository;
    private readonly Lazy<IEventProductUsageRepository> _eventProductUsageRepository;
    private readonly Lazy<IWarehouseProductRepository> _warehouseProductRepository;
    private readonly Lazy<IProductCategoryRepository> _categoryRepository;


    private readonly RepositoryContext _repositoryContext;


    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;

        _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(_repositoryContext));
        _eventProductUsageRepository =
            new Lazy<IEventProductUsageRepository>(() => new EventProductUsageRepository(_repositoryContext));
        _warehouseProductRepository =
            new Lazy<IWarehouseProductRepository>(() => new WarehouseProductRepository(_repositoryContext));
        _categoryRepository =
            new Lazy<IProductCategoryRepository>(() => new ProductCategoryRepository(_repositoryContext));
    }

    public IProductRepository Product => _productRepository.Value;
    public IProductCategoryRepository Category => _categoryRepository.Value;


    public async Task SaveAsync()
    {
        await _repositoryContext.SaveChangesAsync();
    }


    public void Save()
    {
        _repositoryContext.SaveChanges();
    }
}