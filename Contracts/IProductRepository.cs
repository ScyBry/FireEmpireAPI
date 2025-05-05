using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts
{
    public interface IProductRepository : IRepositoryBase<ProductEntity>
    {
        Task<PagedList<ProductEntity>> GetProductsAsync(ProductParameters parameters, bool trackChanges);
        Task<IEnumerable<ProductEntity>> GetProductsByCategoryAsync(Guid categoryId, bool trackChanges);
        Task<IEnumerable<ProductEntity>> GetProductsByHazardClassAsync(HazardClass hazardClass, bool trackChanges);
        Task<IEnumerable<ProductEntity>> GetProductsByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        Task<IEnumerable<ProductEntity>> GetProductsWithDetailsAsync(bool trackChanges);
        Task<ProductEntity> GetProductWithDetailsAsync(Guid id, bool trackChanges);
    }
}