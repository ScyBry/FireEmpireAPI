using Entities.Models;

namespace Contracts
{
    public interface IWarehouseProductRepository : IRepositoryBase<WarehouseProduct>
    {
        Task<WarehouseProduct> GetProductInWarehouseAsync(Guid productId, Guid warehouseId, bool trackChanges);
        Task<IEnumerable<WarehouseProduct>> GetProductsInWarehouseAsync(Guid warehouseId, bool trackChanges);
    }
}