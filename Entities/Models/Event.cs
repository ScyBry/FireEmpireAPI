using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Event
    {
        [Key] public Guid Id { get; set; }
        public string EventName { get; set; }
    }
}