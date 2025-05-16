using Entities.Models;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Contracts
{
    public interface IProductCategoryRepository
    {
        Task<IEnumerable<ProductCategoryEntity>> GetAllCategoriesAsync(CategoryParameters parameters,
            bool trackChanges);

        Task<ProductCategoryEntity> GetCategoryAsync(Guid categoryId, bool trackChanges,
            bool includeProducts = false);

        void CreateCategory(ProductCategoryEntity productCategory);
        void DeleteCategory(ProductCategoryEntity productCategory);

        Task<bool> CategoryHasProductsAsync(Guid categoryId);
    }
}