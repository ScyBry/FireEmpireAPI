using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace FIreEmpireAPI.Presentation.Controllers
{

    [Route("api/contacts")]
    [ApiController]
    public class ContactController : ControllerBase
    {

        private readonly IServiceManager _serviceManager;

        public ContactController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            var contacts = await _serviceManager.ContactService.GetAllContactsAsync(trackChanges: false);
            return Ok(contacts);
        }


        [HttpGet("{id:guid}", Name = "ContactById")]
        public async Task<IActionResult> GetContact(Guid id)
        {
            var contact = await _serviceManager.ContactService.GetContactByIdAsync(id, trackChanges: false);
            return Ok(contact);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] ContactForCreationDto contactDto)
        {
            if (contactDto == null)
                return BadRequest("ContactForCreationDto объект равен null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var contactToReturn = await _serviceManager.ContactService.CreateContactAsync(contactDto);

            return CreatedAtRoute("ContactById", new { id = contactToReturn.Id }, contactToReturn);
        }


        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateContact(Guid id, [FromBody] ContactForUpdateDto contactDto)
        {
            if (contactDto == null)
                return BadRequest("ContactForUpdateDto объект равен null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _serviceManager.ContactService.UpdateContactAsync(id, contactDto, trackChanges: true);

            return NoContent();
        }


        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteContact(Guid id)
        {
            await _serviceManager.ContactService.DeleteContactAsync(id, trackChanges: false);

            return NoContent();
        }
    }
}
