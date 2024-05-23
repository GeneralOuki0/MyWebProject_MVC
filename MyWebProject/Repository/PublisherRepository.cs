using MyWebProject.Data;
using MyWebProject.DataAccess.Repository;
using MyWebProject.Models;
using MyWebProject.Repository.IRepository;

namespace MyWebProject.Repository
{
    public class PublisherRepository : Repository<Publisher>, IPublisherRepository
    {
        private ApplicationdbContext _db;
        public PublisherRepository(ApplicationdbContext db) : base(db)
        {
            _db = db;
        }

        

        public void Update(Publisher obj)
        {
            _db.Publishers.Update(obj);
        }
    }
}
