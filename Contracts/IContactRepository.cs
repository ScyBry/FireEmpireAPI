using Entities.Models;

namespace Contracts
{
    public interface IContactRepository
    {
        Task<IEnumerable<ContactEntity>> GetAllContacts(bool trackChanges);
        Task<ContactEntity> GetContactByID(Guid id, bool trackChanges);
        Task CreateContact(ContactEntity contactEntity);
        void DeleteContact(ContactEntity contactEntity);
        void UpdateContact(ContactEntity contactEntity);
    }
}