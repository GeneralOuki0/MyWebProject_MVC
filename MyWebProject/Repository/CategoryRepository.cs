using MyWebProject.Data;
using MyWebProject.DataAccess.Repository;
using MyWebProject.Models;
using MyWebProject.Repository.IRepository;

namespace MyWebProject.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationdbContext _db;
        public CategoryRepository(ApplicationdbContext db) : base(db)
        {
            _db = db;
        }

        

        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
