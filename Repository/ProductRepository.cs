using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;

namespace Repository
{


    public class ProductRepository : RepositoryBase<ProductEntity>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<PagedList<ProductEntity>> GetProductsAsync(
            ProductParameters parameters,
            bool trackChanges)
        {
            var query = FindAll(trackChanges)
                .Include(p => p.Category)
                .Include(p => p.WarehouseProducts)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(parameters.Category))
                query = query.Where(p => p.Category.CategoryName.Contains(parameters.Category));

            if (parameters.MinPrice.HasValue)
                query = query.Where(p => p.ProductPrice >= parameters.MinPrice);

            if (parameters.MaxPrice.HasValue)
                query = query.Where(p => p.ProductPrice <= parameters.MaxPrice);

            if (parameters.HazardClass.HasValue)
                query = query.Where(p => p.HazardClass == parameters.HazardClass);


            if (!string.IsNullOrWhiteSpace(parameters.SearchTerm))
            {
                query = query.Where(p =>
                    p.ProductName.Contains(parameters.SearchTerm) ||
                    p.Category.CategoryName.Contains(parameters.SearchTerm));
            }


            //if (!string.IsNullOrWhiteSpace(parameters.OrderBy))
            //    query = query.OrderBy(parameters.OrderBy);

            return PagedList<ProductEntity>.ToPagedList(
                query,
                parameters.PageNumber,
                parameters.PageSize);
        }

        public async Task<IEnumerable<ProductEntity>> GetProductsByCategoryAsync(
            Guid categoryId,
            bool trackChanges) =>
            await FindByCondition(p => p.CategoryId.Equals(categoryId), trackChanges)
                .Include(p => p.Category)
                .ToListAsync();

        public async Task<IEnumerable<ProductEntity>> GetProductsWithDetailsAsync(
            bool trackChanges) =>
            await FindAll(trackChanges)
                .Include(p => p.Category)
                .Include(p => p.WarehouseProducts)
                    .ThenInclude(wp => wp.Warehouse)
                .Include(p => p.ProductUsages)
                    .ThenInclude(pu => pu.Event)
                .ToListAsync();

        public async Task<ProductEntity> GetProductWithDetailsAsync(
            Guid id,
            bool trackChanges) =>
            await FindByCondition(p => p.Id.Equals(id), trackChanges)
                .Include(p => p.Category)
                .Include(p => p.WarehouseProducts)
                    .ThenInclude(wp => wp.Warehouse)
                .Include(p => p.ProductUsages)
                    .ThenInclude(pu => pu.Event)
                .SingleOrDefaultAsync();

        public async Task<IEnumerable<ProductEntity>> GetProductsByHazardClassAsync(
            HazardClass hazardClass,
            bool trackChanges) =>
            await FindByCondition(p => p.HazardClass == hazardClass, trackChanges)
                .Include(p => p.Category)
                .ToListAsync();

        public async Task<IEnumerable<ProductEntity>> GetProductsByIdsAsync(
            IEnumerable<Guid> ids,
            bool trackChanges) =>
            await FindByCondition(p => ids.Contains(p.Id), trackChanges)
                .Include(p => p.Category)
                .Include(p => p.WarehouseProducts)
                .ToListAsync();
    }
}
