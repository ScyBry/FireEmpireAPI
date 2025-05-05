using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Repository
{
    public class ProductCategoryRepository : RepositoryBase<ProductCategoryEntity>, IProductCategoryRepository
    {
        public ProductCategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<PagedList<ProductCategoryEntity>> GetAllCategoriesAsync(CategoryParameters parameters,
            bool trackChanges)
        {
            var query = FindAll(trackChanges)
                .Include(pc => pc.Products)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(parameters.SearchTerm))
            {
                query = query.Where(pc =>
                    pc.CategoryName.Contains(parameters.SearchTerm));
            }

            if (!string.IsNullOrWhiteSpace(parameters.OrderBy))
            {
                query = query.OrderBy(parameters.OrderBy);
            }

            return PagedList<ProductCategoryEntity>.ToPagedList(
                query,
                parameters.PageNumber,
                parameters.PageSize);
        }


        public async Task<ProductCategoryEntity> GetCategoryAsync(Guid categoryId, bool trackChanges,
            bool includeProducts = false)
        {
            var query = FindByCondition(pc => pc.Id.Equals(categoryId), trackChanges);

            if (includeProducts)
            {
                query = query.Include(pc => pc.Products);
            }

            return await query.SingleOrDefaultAsync();
        }


        public async Task<bool> CategoryHasProductsAsync(Guid categoryId)
        {
            return await FindByCondition(pc => pc.Id.Equals(categoryId), false)
                .AnyAsync(pc => pc.Products.Any());
        }
    }
}