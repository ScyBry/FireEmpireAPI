using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class ProductRepository : RepositoryBase<Product>, IProductRepository
{
    public ProductRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).OrderBy(c => c.CreatedAt).ToListAsync();
    }

    public void CreateProduct(Product product)
    {
        Create(product);
    }

    public void DeleteProduct(Product product)
    {
        Delete(product);
    }

    public async Task<Product> GetProductAsync(Guid id, bool trackChanges)
    {
        return await FindByCondition(c => c.Id.Equals(id), trackChanges).SingleOrDefaultAsync();
    }
}