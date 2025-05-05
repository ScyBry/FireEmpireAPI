namespace Entities.Exceptions
{
    public sealed class CategoryNotFoundException : NotFoundException
    {
        public CategoryNotFoundException(Guid categoryId)
            : base($"Category with id: {categoryId} doesn't exist in the database.")
        {
        }
    }

    public sealed class CannotDeleteCategoryWithProductsException : BadRequestException
    {
        public CannotDeleteCategoryWithProductsException(Guid categoryId)
            : base($"Cannot delete category with id: {categoryId}. It has related products.")
        {
        }
    }
}