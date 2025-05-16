using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IProductCategoryService> _categoryService;
    private readonly Lazy<IProductService> _productService;


    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
    {
        _categoryService =
            new Lazy<IProductCategoryService>(() => new ProductCategoryService(repositoryManager, logger, mapper));

        _productService = new Lazy<IProductService>(() => new ProductService(repositoryManager, mapper, logger));
    }


    public IProductCategoryService CategoryService => _categoryService.Value;
    public IProductService ProductService => _productService.Value;
}