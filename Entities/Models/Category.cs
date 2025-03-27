using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        
        public ICollection<Product> Products { get;  } = new List<Product>();
    }
}