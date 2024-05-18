using MyWebProject.Models;

namespace MyWebProject.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product obj);
        
    }
}
