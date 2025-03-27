using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Repository;

public class ProductRepository : RepositoryBase<Product>
{
    public ProductRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges) =>
        await FindAll(trackChanges).OrderBy(product => product.ProductName).ToListAsync();

    public async Task<Product> GetProductByIdAsync(Guid productId, bool trackChanges) =>
        await FindByCondition(product => product.Id == productId, trackChanges).FirstOrDefaultAsync();

    public void Create(Product product) => Create(product);
    public void Delete(Product product) => Delete(product);
}