namespace Entities.Models
{
    public class ProductCategoryEntity : BaseEntity
    {
        public string CategoryName { get; set; }

        public ICollection<ProductEntity> Products { get; set; } = new List<ProductEntity>();
    }
}
