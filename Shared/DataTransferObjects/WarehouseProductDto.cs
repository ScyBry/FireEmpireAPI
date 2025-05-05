using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public class WarehouseProductDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public Guid WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public int TotalQuantity { get; set; }
        public int ReservedQuantity { get; set; }
        public int AvailableQuantity => TotalQuantity - ReservedQuantity;
    }

    public class WarehouseProductUpdateDto
    {
        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public Guid WarehouseId { get; set; }

        [Range(0, int.MaxValue)]
        public int TotalQuantity { get; set; }

        [Range(0, int.MaxValue)]
        public int ReservedQuantity { get; set; }
    }
}
