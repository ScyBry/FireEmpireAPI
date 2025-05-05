using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class EventProductUsageRepository : RepositoryBase<EventProductUsage>, IEventProductUsageRepository
    {
        public EventProductUsageRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<EventProductUsage>> GetUsagesForEventAsync(Guid eventId, bool trackChanges) =>
          await FindByCondition(epu => epu.EventId.Equals(eventId), trackChanges)
              .ToListAsync();
    }
}
