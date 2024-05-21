using MyWebProject.Data;
using MyWebProject.Repository.IRepository;

namespace MyWebProject.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationdbContext _db;
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }
        public ICartItemRepository CartItem { get; private set; }
        public IReviewRepository Review { get; private set; }
        public UnitOfWork(ApplicationdbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
            CartItem = new CartItemRepository(_db);
            Review = new ReviewRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
