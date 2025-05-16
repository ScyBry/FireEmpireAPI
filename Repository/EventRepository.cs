using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class EventRepository : RepositoryBase<Event>
    {
        public EventRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }


        public async Task<IEnumerable<Event>> GetAllEventsAsync(bool includeEventProducts, bool trackChanges)
        {
            var query = FindAll(trackChanges).AsQueryable();

            if (includeEventProducts)
                query.Include(e => e.ProductUsages).ThenInclude(pu => pu.Product);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Event>> GetUpcomingEventsAsync(bool trackChanges) =>
            await FindByCondition(e => e.StartDate > DateTime.UtcNow && !e.isDeleted, trackChanges)
                .OrderBy(e => e.StartDate).ToListAsync();

        public void CreateEvent(Event eventEntity) => CreateAsync(eventEntity);
        public void DeleteEvent(Event eventEntity) => Delete(eventEntity);
    }
}