namespace Service.Contracts;

public interface IServiceManager
{
    IProjectService ProjectService { get; }
    IProductService ProductService { get; }
    IFileService FileService { get; }
    IEmailService EmailService { get; }
    IFireworksService FireworksService { get; }
}