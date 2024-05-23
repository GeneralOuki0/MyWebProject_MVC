using MyWebProject.Models;

namespace MyWebProject.Repository.IRepository
{
    public interface IPublisherRepository : IRepository<Publisher>
    {
        void Update(Publisher obj);
        
    }
}
