using Microsoft.AspNetCore.Http;

namespace Service.Contracts;

public interface IFileService
{
    Task<string> SaveFileAsync(IFormFile file, string projectName);
    void DeleteFile(string filePath);
    Task<List<string>> SaveFilesAsync(List<IFormFile> files, string projectName);
}