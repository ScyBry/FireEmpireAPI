using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    namespace Entities.DTOs
    {
        public class EventDto
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public string Location { get; set; }
            public string Organizer { get; set; }
            public ICollection<EventProductUsageDto> ProductUsages { get; set; }
        }

        public class EventCreateDto
        {
            [Required]
            public string Name { get; set; }

            [Required]
            public DateTime StartDate { get; set; }

            [Required]
            public DateTime EndDate { get; set; }

            [Required]
            public string Location { get; set; }

            public string Organizer { get; set; }
        }

        public class EventProductUsageDto
        {
            public Guid ProductId { get; set; }
            public string ProductName { get; set; }
            public Guid WarehouseId { get; set; }
            public string WarehouseName { get; set; }
            public int QuantityUsed { get; set; }
            public bool IsReturned { get; set; }
        }

        public class EventProductUsageCreateDto
        {
            [Required]
            public Guid ProductId { get; set; }

            [Required]
            public Guid WarehouseId { get; set; }

            [Range(1, int.MaxValue)]
            public int QuantityUsed { get; set; }
        }
    }
}
