namespace Entities.Models
{
    public class Event : BaseEntity
    {
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public DateTime StartDate { get; set; }
        public string Location { get; set; }


        public ICollection<EventProductUsage> ProductUsages { get; set; } = new List<EventProductUsage>();
    }
}
