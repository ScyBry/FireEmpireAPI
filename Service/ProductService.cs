using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects.Product;

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
        var products = await _repository.Product.GetAllProductsAsync(trackChanges);
        var productsToReturn = _mapper.Map<IEnumerable<ProductDTO>>(products);
        return productsToReturn;
    }

    public async Task<ProductDTO> GetProductByIdAsync(Guid id, bool trackChanges)
    {
        var product = await GetProductAndCheckIfItExists(id, trackChanges);
        var productToReturn = _mapper.Map<ProductDTO>(product);
        return productToReturn;
    }


    public async Task DeleteProductAsync(Guid productId, bool trackChanges)
    {
        var product = await GetProductAndCheckIfItExists(productId, trackChanges);

        _repository.Product.DeleteProduct(product);
        await _repository.SaveAsync();
    }

    public async Task<ProductDTO> CreateProductAsync(ProductForCreationDTO product)
    {
        var productEntity = _mapper.Map<Product>(product);

        var imagesPath = await _fileService.SaveFilesAsync(product.Images, product.Name);
        productEntity.ImagesPath = imagesPath;

        _repository.Product.CreateProduct(productEntity);
        await _repository.SaveAsync();

        var productToReturn = _mapper.Map<ProductDTO>(productEntity);
        return productToReturn;
    }


    private async Task<Product> GetProductAndCheckIfItExists(Guid id, bool trackChanges)
    {
        var product = await _repository.Product.GetProductAsync(id, trackChanges);
        if (product is null) throw new ProductNotFoundException(id);

        return product;
    }
}