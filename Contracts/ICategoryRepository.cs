using Entities.Models;
using System.Collections;

namespace Contracts
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges, bool withProducts);
        Task<Category> GetCategoryByIdAsync(Guid categoryId, bool trackChanges, bool withProducts);
        void CreateCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
    }
}