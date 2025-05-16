using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using OfficeOpenXml.Packaging.Ionic.Zip;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;


namespace Service
{
    public class ProductService : IProductService
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


        public async Task<(IEnumerable<ProductDto> products, MetaData metaData)> GetAllProductsAsync(
            ProductParameters parameters, bool trackChanges)
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
            var category = await _repositoryManager.Product.GetByIdAsync(productDto.CategoryId, trackChanges: false);
            if (category is null)
            {
                throw new CategoryNotFoundException(productDto.CategoryId);
            }

            var productEntity = _mapper.Map<ProductEntity>(productDto);

            await _repositoryManager.Product.CreateAsync(productEntity);
            await _repositoryManager.SaveAsync();

            return _mapper.Map<ProductDto>(productEntity);
        }


        public async Task UpdateProductAsync(
            Guid productId,
            ProductForUpdateDto productDto,
            bool trackChanges)
        {
            var productEntity = await _repositoryManager.Product
                .GetByIdAsync(productId, trackChanges);

            if (productEntity is null)
                throw new ProductNotFoundException(productId);


            if (productDto.CategoryId != productEntity.CategoryId)
            {
                var category = await _repositoryManager.Category
                    .GetCategoryAsync(productDto.CategoryId, trackChanges: false);

                if (category is null)
                    throw new CategoryNotFoundException(productDto.CategoryId);
            }

            _mapper.Map(productDto, productEntity);
            await _repositoryManager.SaveAsync();
        }

        public async Task DeleteProductAsync(Guid productId, bool trackChanges)
        {
            var product = await _repositoryManager.Product
                .GetByIdAsync(productId, trackChanges);

            if (product is null)
                throw new ProductNotFoundException(productId);

            _repositoryManager.Product.Delete(product);
            await _repositoryManager.SaveAsync();
        }

        public async Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(
            Guid categoryId,
            ProductParameters productParameters,
            bool trackChanges)
        {
            await CheckIfCategoryExists(categoryId, trackChanges);

            var productEntities = await _repositoryManager.Product
                .GetProductsByCategoryAsync(categoryId, trackChanges);

            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(productEntities);

            return productsDto;
        }

        public async Task<IEnumerable<ProductDto>> GetProductsByHazardClassAsync(
            HazardClass hazardClass,
            bool trackChanges)
        {
            var products = await _repositoryManager.Product
                .GetProductsByHazardClassAsync(hazardClass, trackChanges);

            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<IEnumerable<ProductDto>> GetProductsByIdsAsync(
            IEnumerable<Guid> ids,
            bool trackChanges)
        {
            if (ids is null)
                throw new ArgumentNullException(nameof(ids));

            var productEntities = await _repositoryManager.Product
                .GetProductsByIdsAsync(ids, trackChanges);

            if (ids.Count() != productEntities.Count())
                throw new BadReadException();

            return _mapper.Map<IEnumerable<ProductDto>>(productEntities);
        }

        private async Task CheckIfCategoryExists(Guid categoryId, bool trackChanges)
        {
            var category = await _repositoryManager.Category
                .GetCategoryAsync(categoryId, trackChanges);

            if (category is null)
                throw new CategoryNotFoundException(categoryId);
        }
    }
}