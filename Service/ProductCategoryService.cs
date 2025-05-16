using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service
{
    public class ProductCategoryService : IProductCategoryService
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

        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync(
            CategoryParameters parameters, bool trackChanges)
        {
            var categories =
                await _repositoryManager.Category.GetAllCategoriesAsync(parameters, trackChanges);

            var categoriesDtos = _mapper.Map<IEnumerable<CategoryDto>>(categories);

            return categoriesDtos;
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

            _repositoryManager.Category.CreateCategory(categoryEntity);
            await _repositoryManager.SaveAsync();

            return _mapper.Map<CategoryDto>(categoryEntity);
        }

        public async Task UpdateCategoryAsync(Guid categoryId, ProductCategoryForUpdateDto categoryDto,
            bool trackChanges)
        {
            var categoryEntity = await _repositoryManager.Category.GetCategoryAsync(categoryId, trackChanges);
            if (categoryEntity is null)
            {
                throw new CategoryNotFoundException(categoryId);
            }

            _mapper.Map(categoryDto, categoryEntity);
            await _repositoryManager.SaveAsync();
        }

        public async Task DeleteCategoryAsync(Guid categoryId, bool trackChanges)
        {
            var category = await _repositoryManager.Category.GetCategoryAsync(categoryId, trackChanges);
            if (category is null)
            {
                throw new CategoryNotFoundException(categoryId);
            }

            if (await _repositoryManager.Category.CategoryHasProductsAsync(categoryId))
                throw new CannotDeleteCategoryWithProductsException(categoryId);

            _repositoryManager.Category.DeleteCategory(category);
            await _repositoryManager.SaveAsync();
        }
    }
}