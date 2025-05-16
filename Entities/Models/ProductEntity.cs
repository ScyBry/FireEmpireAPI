namespace Entities.Models
{
    public enum HazardClass
    {
        Class1 = 1, Class2 = 2, Class3 = 3, Class4 = 4, Class5 = 5
    }

    public class ProductEntity : BaseEntity
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string VideoUrl { get; set; }
        public HazardClass HazardClass { get; set; }

        public Guid CategoryId { get; set; }
        public ProductCategoryEntity Category { get; set; }


        public ICollection<WarehouseProduct> WarehouseProducts { get; set; } = new List<WarehouseProduct>();
        public ICollection<EventProductUsage> ProductUsages { get; set; } = new List<EventProductUsage>();
    }
}