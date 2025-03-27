using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Warehouse
    {
        [Key] public Guid Id { get; set; }

        public string WarehouseName { get; set; }
        public string WarehouseLocation { get; set; }
    }
}