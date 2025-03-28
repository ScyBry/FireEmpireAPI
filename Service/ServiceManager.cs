using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IEmailService> _emailService;
    private readonly Lazy<IFileService> _fileService;
    private readonly Lazy<IProductService> _productService;


    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
    {
        _productService =
            new Lazy<IProductService>(() => new ProductService(repositoryManager, logger, mapper));
        _fileService = new Lazy<IFileService>(() => new FileService(repositoryManager, logger, mapper));

        _emailService = new Lazy<IEmailService>(() => new EmailService(logger, mapper));
    }

    public IProductService ProductService => _productService.Value;
    public IFileService FileService => _fileService.Value;
    public IEmailService EmailService => _emailService.Value;
}