using MyWebProject.Models;

namespace MyWebProject.Repository.IRepository
{
    public interface ICartItemRepository : IRepository<CartItem>
    {
        void Update(CartItem obj);
        
    }
}
