using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Shared.DataTransferObjects.Projects;

public record ProjectDTO
{
    public Guid Id { get; init; }
    public DateTime Date { get; init; }

    [Required(ErrorMessage = "Название проекта является обязательным полем")]
    [DataType(DataType.Text)]
    [MaxLength(200, ErrorMessage = "Название проекта не может превышать 200 символов")]
    public string Name { get; init; }

    [Required(ErrorMessage = "Описание является обязательным полем")]
    [DataType(DataType.Text)]
    [MinLength(10, ErrorMessage = "Описание должно содержать не менее 10 символов")]
    public string Description { get; init; }

    public List<string>? ImagesPath { get; init; }
}

public record ProjectForManipulationDTO
{
    [Required(ErrorMessage = "Название проекта является обязательным полем")]
    [DataType(DataType.Text)]
    [MaxLength(200, ErrorMessage = "Название проекта не может превышать 200 символов")]
    public string? Name { get; init; }

    [Required(ErrorMessage = "Дата является обязательным полем")]
    [DataType(DataType.Date)]
    public DateTime? Date { get; init; }

    [Required(ErrorMessage = "Описание является обязательным полем")]
    [DataType(DataType.Text)]
    [MinLength(10, ErrorMessage = "Описание должно содержать не менее 10 символов")]
    public string? Description { get; init; }

    [Required(ErrorMessage = "Изображения являются обязательным полем")]
    [DataType(DataType.Upload)]
    [MinLength(1, ErrorMessage = "Необходимо загрузить хотя бы одно изображение")]
    public List<IFormFile> Images { get; init; }
}

public record ProjectForCreationDTO : ProjectForManipulationDTO
{
};