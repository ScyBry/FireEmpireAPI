using Entities.Models;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service.Contracts
{
    public interface IProductService
    {
        Task<(IEnumerable<ProductDto> products, MetaData metaData)> GetAllProductsAsync(
            ProductParameters parameters, bool trackChanges);

        Task<ProductDto> GetProductAsync(Guid productId, bool trackChanges);
        Task<ProductDto> CreateProductAsync(ProductForCreationDto productDto);

        Task UpdateProductAsync(
            Guid productId,
            ProductForUpdateDto productDto,
            bool trackChanges);

        Task DeleteProductAsync(Guid productId, bool trackChanges);

        Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(
            Guid categoryId,
            ProductParameters productParameters,
            bool trackChanges);

        Task<IEnumerable<ProductDto>> GetProductsByHazardClassAsync(
            HazardClass hazardClass,
            bool trackChanges);

        Task<IEnumerable<ProductDto>> GetProductsByIdsAsync(
            IEnumerable<Guid> ids,
            bool trackChanges);
    }
}