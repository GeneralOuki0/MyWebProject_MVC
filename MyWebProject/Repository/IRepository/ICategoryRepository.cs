using MyWebProject.Models;

namespace MyWebProject.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category obj);
        
    }
}
