using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class WarehouseProductRepository : RepositoryBase<WarehouseProduct>, IWarehouseProductRepository
    {
        public WarehouseProductRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }


        public async Task<WarehouseProduct> GetProductInWarehouseAsync(Guid productId, Guid warehouseId, bool trackChanges) =>
           await FindByCondition(wp => wp.ProductId.Equals(productId) && wp.WarehouseId.Equals(warehouseId), trackChanges)
               .SingleOrDefaultAsync();

        public async Task<IEnumerable<WarehouseProduct>> GetProductsInWarehouseAsync(Guid warehouseId, bool trackChanges) =>
            await FindByCondition(wp => wp.WarehouseId.Equals(warehouseId), trackChanges)
                .ToListAsync();
    }
}