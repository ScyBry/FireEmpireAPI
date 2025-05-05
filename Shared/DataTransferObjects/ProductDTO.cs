using Entities.Models;
using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record ProductDto
    {
        public Guid Id { get; init; }
        public string ProductName { get; init; }
        public decimal ProductPrice { get; init; }
        public HazardClass HazardClass { get; init; }
        public Guid CategoryId { get; init; }
        public string CategoryName { get; init; }
        public IEnumerable<WarehouseStockDto> WarehouseStocks { get; init; }
    }


    public record ProductForCreationDto
    {
        [Required(ErrorMessage = "Product name is required")]
        [MaxLength(200, ErrorMessage = "Maximum length for the Name is 200 characters.")]
        public string ProductName { get; init; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be positive")]
        public decimal ProductPrice { get; init; }

        [Required]
        public HazardClass HazardClass { get; init; }

        [Required]
        public Guid CategoryId { get; init; }
    }


    public record ProductForUpdateDto
    {
        [Required(ErrorMessage = "Product name is required")]
        [MaxLength(200, ErrorMessage = "Maximum length for the Name is 200 characters.")]
        public string ProductName { get; init; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be positive")]
        public decimal ProductPrice { get; init; }

        [Required]
        public HazardClass HazardClass { get; init; }

        [Required]
        public Guid CategoryId { get; init; }
    }
}
