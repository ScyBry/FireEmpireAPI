using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.DataTransferObjects;

public class FireworkDTO
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public int Quantity { get; init; }
    public string VideoLink { get; init; }
    public string HazardClass { get; init; }
    public decimal PricePerUnit { get; init; }
    public decimal PricePerBox { get; init; }
}

public class FireworkForCreationDTO
{
    [Required(ErrorMessage = "Наименование является обязательным")]
    [DataType(DataType.Text)]
    public string Name { get; set; } // Наименование

    [Required(ErrorMessage = "Количество является обязательным")]
    [Range(1, int.MaxValue, ErrorMessage = "Количество должно быть больше 0")]
    public int Quantity { get; set; } // Количество

    [DataType(DataType.Url)]
    [Url(ErrorMessage = "Ссылка на видео должна быть валидной ссылкой")]
    public string VideoLink { get; set; } // Ссылка на видео

    [Required(ErrorMessage = "Класс опасности является обязательным")]
    [MaxLength(50, ErrorMessage = "Класс опасности не может превышать 50 символов")]
    public string HazardClass { get; set; } // Класс опасности

    [Required(ErrorMessage = "Цена за штуку является обязательным полем")]
    [DataType(DataType.Currency)]
    [Range(0.01, double.MaxValue, ErrorMessage = "Цена за штуку должна быть больше 0")]
    public decimal PricePerUnit { get; set; } // Цена за штуку

    [Required(ErrorMessage = "Цена за коробку является обязательным полем")]
    [DataType(DataType.Currency)]
    [Range(0.01, double.MaxValue, ErrorMessage = "Цена за коробку должна быть больше 0")]
    public decimal PricePerBox { get; set; }
}