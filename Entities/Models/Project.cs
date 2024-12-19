using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Project
{
    [Column("ProjectID")] public Guid Id { get; set; }

    [Required(ErrorMessage = "Название проекта является обязательным")]
    [DataType(DataType.Text)]
    [MaxLength(100, ErrorMessage = "Название проекта не может превышать 100 символов")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Дата является обязательным полем")]
    [DataType(DataType.Date)]
    public DateTime? Date { get; set; }

    [Required(ErrorMessage = "Описание является обязательным")]
    [DataType(DataType.Text)]
    [MinLength(10, ErrorMessage = "Описание должно содержать не менее 10 символов")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Путь к изображениям является обязательным")]
    public List<string> ImagesPath { get; set; } = new();

    [DataType(DataType.DateTime)] public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [DataType(DataType.DateTime)] public DateTime? UpdatedAt { get; set; }
}