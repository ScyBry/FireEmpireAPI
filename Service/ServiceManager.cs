using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IProductCategoryService> _categoryService;
    private readonly Lazy<IProductService> _productService;
    private readonly Lazy<IContactService> _cotntactService;


    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
    {
        _categoryService =
            new Lazy<IProductCategoryService>(() => new ProductCategoryService(repositoryManager, logger, mapper));

        _productService = new Lazy<IProductService>(() => new ProductService(repositoryManager, mapper, logger));

        _cotntactService = new Lazy<IContactService>(() => new ContactService(repositoryManager, logger, mapper));
    }


    public IProductCategoryService CategoryService => _categoryService.Value;
    public IProductService ProductService => _productService.Value;
    public IContactService ContactService => _cotntactService.Value;
}