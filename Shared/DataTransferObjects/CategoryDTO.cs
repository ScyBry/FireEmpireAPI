namespace Shared.DataTransferObjects
{
    public record CategoryDTO()
    {
        public Guid Id { get; init; }
        public string CategoryName { get; init; }
    }

    public record CategoryForCreationDTO
    {
        public string CategoryName { get; init; }
    }

    public record CategoryForManipulationDTO : CategoryDTO
    {
    }
}