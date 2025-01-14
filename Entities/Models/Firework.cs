using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Firework
    {
        [Column("FireworkID")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Наименование является обязательным")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Количество является обязательным")]
        [Range(1, int.MaxValue, ErrorMessage = "Количество должно быть больше 0")]
        public int Quantity { get; set; }

        [DataType(DataType.Url)]
        [Url(ErrorMessage = "Ссылка на видео должна быть валидной ссылкой")]
        public string VideoLink { get; set; }

        [Required(ErrorMessage = "Класс опасности является обязательным")]
        [MaxLength(50, ErrorMessage = "Класс опасности не может превышать 50 символов")]
        public string HazardClass { get; set; }

        [Required(ErrorMessage = "Цена за штуку является обязательным полем")]
        [DataType(DataType.Currency)]
        [Range(0.01, double.MaxValue, ErrorMessage = "Цена за штуку должна быть больше 0")]
        public decimal PricePerUnit { get; set; }

        [Required(ErrorMessage = "Цена за коробку является обязательным полем")]
        [DataType(DataType.Currency)]
        [Range(0.01, double.MaxValue, ErrorMessage = "Цена за коробку должна быть больше 0")]
        public decimal PricePerBox { get; set; }

        // Связь многие ко многим через таблицу EventFirework
        public ICollection<EventFirework> EventFireworks { get; set; }
    }
}
