using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{


    public class ContactService : IContactService
    {

        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;


        public ContactService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ContactDto>> GetAllContactsAsync(bool trackChanges)
        {
            try
            {
                var contacts = await _repository.Contact.GetAllContacts(trackChanges);
                var contactsDto = _mapper.Map<IEnumerable<ContactDto>>(contacts);
                return contactsDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(GetAllContactsAsync)}: {ex.Message}");
                throw;
            }
        }

        public async Task<ContactDto> GetContactByIdAsync(Guid id, bool trackChanges)
        {
            try
            {
                var contact = await _repository.Contact.GetContactByID(id, trackChanges);

                if (contact == null)
                    throw new ContactNotFoundException(id);

                var contactDto = _mapper.Map<ContactDto>(contact);
                return contactDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(GetContactByIdAsync)}: {ex.Message}");
                throw;
            }
        }

        public async Task<ContactDto> CreateContactAsync(ContactForCreationDto contactDto)
        {
            try
            {
                var contactEntity = _mapper.Map<ContactEntity>(contactDto);

                await _repository.Contact.CreateContact(contactEntity);
                await _repository.SaveAsync();

                var createdContactDto = _mapper.Map<ContactDto>(contactEntity);
                return createdContactDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(CreateContactAsync)}: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateContactAsync(Guid id, ContactForUpdateDto contactForUpdate, bool trackChanges)
        {
            try
            {
                var contactEntity = await _repository.Contact.GetContactByID(id, trackChanges);

                if (contactEntity == null)
                    throw new ContactNotFoundException(id);

                _mapper.Map(contactForUpdate, contactEntity);
                contactEntity.UpdatedAt = DateTime.UtcNow;

                _repository.Contact.UpdateContact(contactEntity);
                await _repository.SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(UpdateContactAsync)}: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteContactAsync(Guid id, bool trackChanges)
        {

            try
            {

                var contact = await _repository.Contact.GetContactByID(id, trackChanges);

                if (contact == null)
                    throw new ContactNotFoundException(id);

                _repository.Contact.DeleteContact(contact);
                await _repository.SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(DeleteContactAsync)}: {ex.Message}");
                throw;
            }
        }
    }

}
