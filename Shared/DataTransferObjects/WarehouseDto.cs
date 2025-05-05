using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public class WarehouseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string ContactPerson { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class WarehouseCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        public string ContactPerson { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class WarehouseUpdateDto : WarehouseCreateDto
    {
        [Required]
        public Guid Id { get; set; }
    }
}
