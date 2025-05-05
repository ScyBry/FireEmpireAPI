using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service
{
    public class ProductCategoryService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;


        public ProductCategoryService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<(IEnumerable<CategoryDto> categories, MetaData metaData)> GetCategoriesAsync(
            CategoryParameters parameters, bool trackChanges)
        {
            var categoriesWithMetaData =
                await _repositoryManager.Category.GetAllCategoriesAsync(parameters, trackChanges);

            var categoriesDtos = _mapper.Map<IEnumerable<CategoryDto>>(categoriesWithMetaData);

            return (categories: categoriesDtos, metaData: categoriesWithMetaData.MetaData);
        }

        public async Task<CategoryDto> GetCategoryAsync(
            Guid categoryId,
            bool trackChanges,
            bool includeProducts = false)
        {
            var category = await _repositoryManager.Category
                .GetCategoryAsync(categoryId, trackChanges, includeProducts);

            if (category is null)
                throw new CategoryNotFoundException(categoryId);

            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<CategoryDto> CreateCategoryAsync(CategoryForCreationDto categoryDto)
        {
            var categoryEntity = _mapper.Map<ProductCategoryEntity>(categoryDto);

            await _repositoryManager.Category.(categoryEntity);
            await _repositoryManager.SaveAsync();

            return _mapper.Map<CategoryDto>(categoryEntity);
        }

        public async Task UpdateCategoryAsync(Guid categoryId, ProductCategoryForUpdateDto categoryDto,
            bool trackChanges)
        {
            var categoryEntity = await _repositoryManager.Category.GetCategoryAsync(categoryId, trackChanges);
            if (categoryEntity is null)
            {
                throw new Carego
            }
        }
    }
}