using Entities.Models;

namespace Contracts
{
    public interface IEventProductUsageRepository : IRepositoryBase<EventProductUsage>
    {
        Task<IEnumerable<EventProductUsage>> GetUsagesForEventAsync(Guid eventId, bool trackChanges);
    }
}