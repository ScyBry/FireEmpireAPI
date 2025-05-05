using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;


namespace Service
{
    public class ProductService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;

        public ProductService(
           IRepositoryManager repository,
           IMapper mapper,
           ILoggerManager logger)
        {
            _repositoryManager = repository;
            _mapper = mapper;
            _logger = logger;
        }


        public async Task<(IEnumerable<ProductDto> products, MetaData metaData)> GetAllProductsAsync(ProductParameters parameters, bool trackChanges)
        {
            var productsWithMetadata = await _repositoryManager.Product.GetProductsAsync(parameters, trackChanges);

            var productsToReturn = _mapper.Map<IEnumerable<ProductDto>>(productsWithMetadata);

            return (products: productsToReturn, metaData: productsWithMetadata.MetaData);
        }

        public async Task<ProductDto> GetProductAsync(Guid productId, bool trackChanges)
        {
            var product = await _repositoryManager.Product.GetProductWithDetailsAsync(productId, trackChanges);
            if (product is null)
            {
                throw new ProductNotFoundException(productId);
            }

            var productDto = _mapper.Map<ProductDto>(product);

            return productDto;
        }

        public async Task<ProductDto> CreateProductAsync(ProductForCreationDto productDto)
        {
            var category = await _repositoryManager.Product
        }



    }
}
