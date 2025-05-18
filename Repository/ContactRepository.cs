using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ContactRepository : RepositoryBase<ContactEntity>, IContactRepository
    {
        public ContactRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }


        public async Task<IEnumerable<ContactEntity>> GetAllContacts(bool trackChanges) =>
            await FindByCondition(c => c.IsDeleted != true, trackChanges).ToListAsync();


        public async Task<ContactEntity> GetContactByID(Guid id, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(id), trackChanges).SingleOrDefaultAsync();


        public Task CreateContact(ContactEntity contactEntity) => CreateAsync(contactEntity);
        public void DeleteContact(ContactEntity contactEntity) => Delete(contactEntity);
        public void UpdateContact(ContactEntity contactEntity) => Update(contactEntity);
    }
}