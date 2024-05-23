namespace MyWebProject.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        ICartItemRepository CartItem { get; }
        IPublisherRepository Publisher { get; }
        void Save();
    }
}
