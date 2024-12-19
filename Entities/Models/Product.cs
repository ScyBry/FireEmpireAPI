using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Product
{
    [Column("ProductID")] public Guid Id { get; set; }

    [Required(ErrorMessage = "Название продукта является обязательным")]
    [DataType(DataType.Text)]
    [MaxLength(100, ErrorMessage = "Название продукта не может превышать 100 символов")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Цена является обязательным полем")]
    [DataType(DataType.Currency)]
    [Range(0.01, double.MaxValue, ErrorMessage = "Цена должна быть больше нуля")]
    public decimal? Price { get; set; }

    [Required(ErrorMessage = "Описание является обязательным")]
    [DataType(DataType.Text)]
    public string? Description { get; set; }

    public List<string> ImagesPath { get; set; } = new();

    [DataType(DataType.DateTime)] public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [DataType(DataType.DateTime)] public DateTime? UpdatedAt { get; set; }
}