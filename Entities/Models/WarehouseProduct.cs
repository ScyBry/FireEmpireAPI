using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class WarehouseProduct : BaseEntity
    {
        public Guid ProductId { get; set; }
        public required ProductEntity Product { get; set; }

        public Guid WarehouseId { get; set; }
        public required Warehouse Warehouse { get; set; }

        public int TotalQuantity { get; set; }
        public int ReservedQuantity { get; set; }


        [NotMapped]
        public int AvailableQuantity => TotalQuantity - ReservedQuantity;
    }
}