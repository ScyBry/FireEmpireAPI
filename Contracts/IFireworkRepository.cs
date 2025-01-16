using Entities.Models;

namespace Contracts;

public interface IFireworkRepository
{
    Task<IEnumerable<Firework>> GetAllFireworksAsync(bool trackChanges);
    Task<Firework> GetFireworkByIdAsync(Guid fireworkId, bool trackChanges);
    Task<Firework> GetFireworkByNormalizedName(string normalizedName, bool trackChanges);
    void CreateFirework(Firework firework);
    void DeleteFirework(Firework firework);
}