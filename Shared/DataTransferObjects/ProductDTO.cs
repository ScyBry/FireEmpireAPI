using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Shared.DataTransferObjects.Product;

public record ProductDTO
{
    public Guid Id { get; init; }

    [Required(ErrorMessage = "Название продукта является обязательным")]
    [DataType(DataType.Text)]
    [MaxLength(100, ErrorMessage = "Название продукта не может превышать 100 символов")]
    public string Name { get; init; }

    [Required(ErrorMessage = "Цена является обязательным полем")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Цена должна быть больше нуля")]
    public decimal? Price { get; init; }

    [Required(ErrorMessage = "Описание является обязательным")]
    [DataType(DataType.Text)]
    public string Description { get; init; }

    public List<string>? ImagesPath { get; init; }
}

public record ProductForManipulationDTO
{
    [Required(ErrorMessage = "Название продукта является обязательным")]
    [DataType(DataType.Text)]
    [MaxLength(100, ErrorMessage = "Название продукта не может превышать 100 символов")]
    public string? Name { get; init; }

    [Required(ErrorMessage = "Цена является обязательным полем")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Цена должна быть больше нуля")]
    public decimal? Price { get; init; }

    [Required(ErrorMessage = "Описание является обязательным")]
    [DataType(DataType.Text)]
    public string? Description { get; init; }

    [Required(ErrorMessage = "Изображения являются обязательным полем")]
    public List<IFormFile> Images { get; init; }
}

public record ProductForCreationDTO : ProductForManipulationDTO
{
};