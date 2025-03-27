namespace Service.Contracts;

public interface IServiceManager
{
    ICategoryService CategoryService { get; }


    IProjectService ProjectService { get; }
    IProductService ProductService { get; }
    IFileService FileService { get; }
    IEmailService EmailService { get; }
    IFireworksService FireworksService { get; }
}