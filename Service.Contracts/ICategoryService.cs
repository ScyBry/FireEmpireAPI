using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service.Contracts
{
    public interface IProductCategoryService
    {
        Task<IEnumerable<CategoryDto>> GetCategoriesAsync(
            CategoryParameters parameters, bool trackChanges);

        Task<CategoryDto> GetCategoryAsync(
            Guid categoryId,
            bool trackChanges,
            bool includeProducts = false);

        Task<CategoryDto> CreateCategoryAsync(CategoryForCreationDto categoryDto);

        Task UpdateCategoryAsync(Guid categoryId, ProductCategoryForUpdateDto categoryDto,
            bool trackChanges);

        Task DeleteCategoryAsync(Guid categoryId, bool trackChanges);
    }
}