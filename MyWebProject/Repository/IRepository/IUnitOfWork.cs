namespace MyWebProject.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        ICartItemRepository CartItem { get; }
        IReviewRepository Review { get; }
        void Save();
    }
}
