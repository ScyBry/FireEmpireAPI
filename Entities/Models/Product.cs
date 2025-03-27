using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Product
    {
        [Key] public Guid Id { get; set; }

        public string ProductName { get; set; }

        [ForeignKey("Category")] public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }

    public class PyrotechnicItem : Product
    {
        public int HazardClass { get; set; }
        public int TotalQuantity { get; set; }
        public string VideoURL { get; set; }
        public float PricePerUnit { get; set; }
    }
}