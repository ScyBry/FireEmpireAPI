namespace Entities.Models
{
    public class WarehouseProduct : BaseEntity
    {
        public Guid ProductId { get; set; }
        public ProductEntity Product { get; set; }

        public Guid WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }

        public int TotalQuantity { get; set; }
        public int ReservedQuantity { get; set; }


        public int AvailableQuantity => TotalQuantity - ReservedQuantity;
    }
}
