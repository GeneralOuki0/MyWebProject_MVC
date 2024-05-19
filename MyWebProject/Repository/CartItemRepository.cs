using MyWebProject.Data;
using MyWebProject.DataAccess.Repository;
using MyWebProject.Models;
using MyWebProject.Repository.IRepository;

namespace MyWebProject.Repository
{
    public class CartItemRepository : Repository<CartItem>, ICartItemRepository
    {
        private ApplicationdbContext _db;
        public CartItemRepository(ApplicationdbContext db) : base(db)
        {
            _db = db;
        }

        

        public void Update(CartItem obj)
        {
            _db.CartItems.Update(obj);
        }
    }
}
