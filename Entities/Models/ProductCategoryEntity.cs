namespace Entities.Models
{
    public class ProductCategoryEntity : BaseEntity
    {
        public required string CategoryName { get; set; }
        public ICollection<ProductEntity> Products { get; set; } = new List<ProductEntity>();
    }
}
