using MyWebProject.Data;
using MyWebProject.DataAccess.Repository;
using MyWebProject.Models;
using MyWebProject.Repository.IRepository;

namespace MyWebProject.Repository
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        private ApplicationdbContext _db;
        public ReviewRepository(ApplicationdbContext db) : base(db)
        {
            _db = db;
        }



        public void Update(Review obj)
        {
            _db.Reviews.Update(obj);
        }
    }
}
