using AutoMapper;
using Contracts;
using Entities.Models;
using Shared.DataTransferObjects;

namespace Service
{
    public class ContactService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;


        public ContactService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;

        }


        public async Task<IEnumerable<ContactDto>> GetAllContactsAsync(bool trackChanges)
        {
            var contacts = await _repositoryManager.Contact.GetAllContacts(trackChanges);
            var contactsDto = _mapper.Map<IEnumerable<ContactDto>>(contacts);
            return contactsDto;
        }


        public async Task<ContactDto> GetContactById(Guid id, bool trackChanges)
        {
            var contact = await _repositoryManager.Contact.GetContactByID(id, trackChanges);

            var contactDto = _mapper.Map<ContactDto>(contact);
            return contactDto;
        }


        public async Task<ContactDto> CreateContact(ContactForCreationDto contactDto)
        {
            var contactEntity = _mapper.Map<ContactEntity>(contactDto);

            await _repositoryManager.Contact.CreateContact(contactEntity);
            await _repositoryManager.SaveAsync();

            var createdContactDto = _mapper.Map<ContactDto>(contactEntity);
            return createdContactDto;
        }


        public as



    }
}