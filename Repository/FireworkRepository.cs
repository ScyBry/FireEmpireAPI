using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class FireworkRepository : RepositoryBase<Firework>, IFireworkRepository
{
    public FireworkRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Firework>> GetAllFireworksAsync(bool trackChanges) =>
        await FindAll(trackChanges).ToListAsync();

    public async Task<Firework> GetFireworkByIdAsync(Guid id, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(id), trackChanges).FirstOrDefaultAsync();

    public async Task<Firework> GetFireworkByNormalizedName(string normalizedName, bool trackChanges) =>
        await FindByCondition(c => c.NormalizedName.Equals(normalizedName), trackChanges).FirstOrDefaultAsync();

    public void CreateFirework(Firework firework) => Create(firework);
    public void DeleteFirework(Firework firework) => Delete(firework);
}