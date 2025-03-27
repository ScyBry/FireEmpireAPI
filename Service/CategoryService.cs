using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using System.Collections;

namespace Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repository;

        public CategoryService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync(bool trackChanges)
        {
            var categories =
                await _repository.CategoryRepository.GetAllCategoriesAsync(trackChanges, withProducts: true);
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public async Task<CategoryDTO> CreateCategoryAsync(CategoryForCreationDTO categoryForCreationDto,
            bool trackChanges)
        {
            var categoryEntity = _mapper.Map<Category>(categoryForCreationDto);

            _repository.CategoryRepository.CreateCategory(categoryEntity);
            await _repository.SaveAsync();

            var categoryToReturn = _mapper.Map<CategoryDTO>(categoryEntity);
            return categoryToReturn;
        }
    }
}