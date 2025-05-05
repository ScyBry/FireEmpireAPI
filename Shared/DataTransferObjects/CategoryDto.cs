using Shared.RequestFeatures;
using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record CategoryDto
    {
        public Guid Id { get; init; }
        public string CategoryName { get; init; }
        public IEnumerable<ProductDto>? Products { get; init; }
    }

    public record CategoryForCreationDto
    {
        [Required(ErrorMessage = "Category name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Category name must be between 3 and 100 characters")]
        public string CategoryName { get; init; }
    }


    public record ProductCategoryForUpdateDto : CategoryForCreationDto;


    public class CategoryParameters : QueryStringParameters
    {
        public string SearchTerm { get; set; }
    }



}
