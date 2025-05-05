using Entities.Models;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Contracts
{
    public interface IProductCategoryRepository
    {
        Task<PagedList<ProductCategoryEntity>> GetAllCategoriesAsync(CategoryParameters parameters,
            bool trackChanges);

        Task<ProductCategoryEntity> GetCategoryAsync(Guid categoryId, bool trackChanges,
            bool includeProducts = false);

        Task<bool> CategoryHasProductsAsync(Guid categoryId);
    }
}