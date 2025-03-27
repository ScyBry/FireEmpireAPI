using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges, bool withProducts = false)
        {
            IQueryable<Category> query = FindAll(trackChanges)
                .OrderBy(category => category.CategoryName);

            if (withProducts)
            {
                query = query.Include(category => category.Products);
            }

            return await query.ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(Guid categoryId, bool trackChanges, bool withProducts = false)
        {
            IQueryable<Category> category = FindByCondition(category => category.Id == categoryId, trackChanges);

            if (withProducts)
            {
                category = category.Include(category => category.Products);
            }

            return await category.FirstOrDefaultAsync();
        }


        public void CreateCategory(Category category) => Create(category);
        public void UpdateCategory(Category category) => Update(category);
        public void DeleteCategory(Category category) => Delete(category);
    }
}