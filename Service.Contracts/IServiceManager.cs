namespace Service.Contracts
{
    public interface IServiceManager
    {
        IProductCategoryService CategoryService { get; }
        IProductService ProductService { get; }

        IContactService ContactService { get; }
    }
}