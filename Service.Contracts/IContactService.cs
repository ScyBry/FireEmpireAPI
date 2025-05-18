using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IContactService
    {
        Task<ContactDto> CreateContactAsync(ContactForCreationDto contactDto);
        Task DeleteContactAsync(Guid id, bool trackChanges);
        Task<IEnumerable<ContactDto>> GetAllContactsAsync(bool trackChanges);
        Task<ContactDto> GetContactByIdAsync(Guid id, bool trackChanges);
        Task UpdateContactAsync(Guid id, ContactForUpdateDto contactForUpdate, bool trackChanges);
    }
}
