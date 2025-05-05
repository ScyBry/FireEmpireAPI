using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class EventRepository : RepositoryBase<Event>
    {
        public EventRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Event>> GetUpcomingEventsAsync(bool trackChanges) =>
            await FindByCondition(e => e.StartDate > DateTime.UtcNow && !e.isDeleted, trackChanges).OrderBy(e => e.StartDate).ToListAsync();


        //public async Task<Event> GetEventWithDetailsAsync(Guid id, bool trackChanges) =>
        //    await FindByCondition(e => e.Id.Equals(id) && !e.isDeleted, trackChanges)
    }
}
