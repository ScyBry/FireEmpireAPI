namespace Entities.Exceptions;

public sealed class ProductNotFoundException : NotFoundException
{
    public ProductNotFoundException(Guid productId) : base($"Product {productId} was not found.")
    {
    }
}