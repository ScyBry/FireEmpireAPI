namespace Entities.Models
{
    public class Warehouse : BaseEntity
    {
        public required string Name { get; set; }
        public required string Location { get; set; }
        public required string ContactPerson { get; set; }
        public required string PhoneNumber { get; set; }


        public  ICollection<WarehouseProduct> WarehouseProducts { get; set; } = new List<WarehouseProduct>();
        public  ICollection<EventProductUsage> ProductUsages { get; set; } = new List<EventProductUsage>();
    }
}