namespace Entities.Models
{
    public class Event : BaseEntity
    {
        public required string EventName { get; set; }
        public string? EventDescription { get; set; }
        public required DateTime StartDate { get; set; }
        public string? Location { get; set; }
        public ICollection<EventProductUsage> ProductUsages { get; set; } = new List<EventProductUsage>();
    }
}
