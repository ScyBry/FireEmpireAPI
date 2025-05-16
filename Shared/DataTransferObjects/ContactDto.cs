using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record ContactDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string MobilePhone { get; init; }
        public string JobTitle { get; init; }
        public DateTime BirthDay { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
    }

    public record ContactForCreationDto
    {
        [Required(ErrorMessage = "Имя обязательно")]
        [StringLength(100, ErrorMessage = "Длина имени не может превышать 100 символов")]
        public string Name { get; init; }

        [Required(ErrorMessage = "Номер телефона обязателен")]
        [Phone(ErrorMessage = "Неверный формат номера телефона")]
        public string MobilePhone { get; init; }

        [StringLength(50, ErrorMessage = "Длина должности не может превышать 50 символов")]
        public string JobTitle { get; init; }

        [DataType(DataType.Date)] public DateTime BirthDay { get; init; }
    }

    public record ContactForUpdateDto
    {
        [Required(ErrorMessage = "Имя обязательно")]
        [StringLength(100, ErrorMessage = "Длина имени не может превышать 100 символов")]
        public string Name { get; init; }

        [Required(ErrorMessage = "Номер телефона обязателен")]
        [Phone(ErrorMessage = "Неверный формат номера телефона")]
        public string MobilePhone { get; init; }

        [StringLength(50, ErrorMessage = "Длина должности не может превышать 50 символов")]
        public string JobTitle { get; init; }

        [DataType(DataType.Date)] public DateTime BirthDay { get; init; }
    }
}