using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class WarehouseStock
    {
        public Guid Id { get; set; }

        [ForeignKey("Warehouse")] public Guid WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }

        [ForeignKey("PyrotechnicItem")] public Guid ProductId { get; set; }
        public PyrotechnicItem PyrotechnicItem { get; set; }
    }
}