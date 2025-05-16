using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Contracts;

namespace Repository
{
    public class ContactRepository : RepositoryBase<ContactEntity>, IContactRepository
    {
        public ContactRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }


        public async Task<IEnumerable<ContactEntity>> GetAllContacts(bool trackChanges) =>
            await FindAll(trackChanges).ToListAsync();


        public async Task<ContactEntity> GetContactByID(Guid id, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(id), trackChanges).SingleOrDefaultAsync();


        public Task CreateContact(ContactEntity contactEntity) => CreateAsync(contactEntity);
        public void DeleteContact(ContactEntity contactEntity) => Delete(contactEntity);
        public void UpdateContact(ContactEntity contactEntity) => Update(contactEntity);
    }
}