using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects.Product;
using System.Collections;

namespace Service;

internal sealed class ProductService : IProductService
{
    private readonly IFileService _fileService;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repository;

    public ProductService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper,
        IFileService fileService)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
        _fileService = fileService;
    }

    public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync(bool trackChanges)
    {
    }
}