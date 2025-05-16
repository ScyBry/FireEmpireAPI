namespace Entities.Models
{
    public class ContactEntity : BaseEntity
    {
        public string Name { get; set; }
        public string MobilePhone { get; set; }
        public string JobTitle { get; set; }
        public DateTime BirthDay { get; set; }
    }
}