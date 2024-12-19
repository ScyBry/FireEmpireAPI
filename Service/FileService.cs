using AutoMapper;
using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Service.Contracts;
using System.IO;

namespace Service;

internal sealed class FileService : IFileService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    private readonly string _baseUploadPath;

    public FileService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
        _baseUploadPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
        
        if (!Directory.Exists(_baseUploadPath))
        {
            Directory.CreateDirectory(_baseUploadPath);
        }
    }

    public async Task<string> SaveFileAsync(IFormFile file, string projectName)
    {
        if (file == null || file.Length == 0)
            throw new ArgumentException("File cannot be null or empty.", nameof(file));
        
        var projectDirectory = Path.Combine(_baseUploadPath, projectName );
        if (!Directory.Exists(projectDirectory))
        {
            Directory.CreateDirectory(projectDirectory);
        }

        var fileExtension = Path.GetExtension(file.FileName);
        var uniqueFileName = $"{Guid.NewGuid()}{fileExtension}";
        var filePath = Path.Combine(projectDirectory, uniqueFileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return Path.Combine("Uploads", projectName, uniqueFileName).Replace("\\", "/");
    }

    public void DeleteFile(string filePath)
    {
        var absolutePath = Path.Combine(_baseUploadPath, filePath);
        if (File.Exists(absolutePath))
        {
            File.Delete(absolutePath);
        }
    }

    public async Task<List<string>> SaveFilesAsync(List<IFormFile> files, string projectName)
    {
        var filePaths = new List<string>();
        string normalizedProjectName = projectName.ToLower().Replace(" ", "-");
        
        
        foreach (var file in files)
        {
            var filePath = await SaveFileAsync(file, normalizedProjectName);
            filePaths.Add(filePath);
        }
        return filePaths;
    }
}