namespace Entities.Models
{
    public class Warehouse : BaseEntity
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string ContactPerson { get; set; }
        public string PhoneNumber { get; set; }


        public ICollection<WarehouseProduct> WarehouseProducts { get; set; } = new List<WarehouseProduct>();
        public ICollection<EventProductUsage> ProductUsages { get; set; } = new List<EventProductUsage>();
    }
}
