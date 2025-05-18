namespace Entities.Models
{
    public class EventProductUsage : BaseEntity
    {
        public Guid EventId { get; set; }
        public required Event Event { get; set; }
        public Guid ProductId { get; set; }
        public required ProductEntity Product { get; set; }
        public Guid WarehouseId { get; set; }
        public required Warehouse Warehouse { get; set; }
        public int QuantityUsed { get; set; }
        public DateTime UsageDate { get; set; }
        public bool IsReturned { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
