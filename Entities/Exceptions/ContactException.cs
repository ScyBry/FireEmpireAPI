namespace Entities.Exceptions
{
    public sealed class ContactNotFoundException : NotFoundException
    {
        public ContactNotFoundException(Guid contactId) : base($"The contact with id: {contactId} doesn't exist in the database.") { }
    }
}
