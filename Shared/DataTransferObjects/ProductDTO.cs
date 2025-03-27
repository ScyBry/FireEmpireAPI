using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Shared.DataTransferObjects.Product;

public record ProductDTO
{
    public Guid Id { get; init; }
    public string ProductName { get; init; }
    public string ProductDescription { get; init; }
    public string VideoURL { get; init; }
}

public record ProductForCreationDTO
{
    public string ProductName { get; init; }
    public string Product
}