namespace Entities.Models
{
    public class ContactEntity : BaseEntity
    {
        public required string Name { get; set; }
        public required string MobilePhone { get; set; }
        public string? JobTitle { get; set; }
        public required DateTime BirthDay { get; set; }
    }
}