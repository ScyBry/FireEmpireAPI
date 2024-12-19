using Shared.DataTransferObjects.Product;

namespace Service.Contracts;

public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetAllProductsAsync(bool trackChanges);
    Task<ProductDTO> GetProductByIdAsync(Guid id, bool trackChanges);
    Task<ProductDTO> CreateProductAsync(ProductForCreationDTO product);
    Task DeleteProductAsync(Guid id, bool trackChanges);
}