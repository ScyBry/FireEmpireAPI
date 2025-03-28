namespace Service.Contracts;

public interface IServiceManager
{
    ICategoryService CategoryService { get; }
    IFileService FileService { get; }
    IEmailService EmailService { get; }
}