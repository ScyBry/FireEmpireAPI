using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IEmailService> _emailService;
    private readonly Lazy<IFileService> _fileService;
    private readonly Lazy<IProductService> _productService;
    private readonly Lazy<IProjectService> _projectService;

    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
    {
        _projectService =
            new Lazy<IProjectService>(() => new ProjectService(repositoryManager, logger, mapper, _fileService.Value));
        _productService =
            new Lazy<IProductService>(() => new ProductService(repositoryManager, logger, mapper, _fileService.Value));
        _fileService = new Lazy<IFileService>(() => new FileService(repositoryManager, logger, mapper));

        _emailService = new Lazy<IEmailService>(() => new EmailService(logger, mapper));
    }

    public IProjectService ProjectService => _projectService.Value;
    public IProductService ProductService => _productService.Value;
    public IFileService FileService => _fileService.Value;
    public IEmailService EmailService => _emailService.Value;
}