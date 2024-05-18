using MyWebProject.Data;
using MyWebProject.DataAccess.Repository;
using MyWebProject.Models;
using MyWebProject.Repository.IRepository;

namespace MyWebProject.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationdbContext _db;
        public ProductRepository(ApplicationdbContext db) : base(db)
        {
            _db = db;
        }

        

        public void Update(Product obj)
        {
            var objFromDb = _db.Products.FirstOrDefault(u => u.Id == obj.Id);
            if(objFromDb != null)
            {
                objFromDb.Title = obj.Title;
                objFromDb.Description = obj.Description;
                objFromDb.Category = obj.Category;
                objFromDb.ISBN = obj.ISBN;
                objFromDb.Price = obj.Price;
                objFromDb.Price50 = obj.Price50;
                objFromDb.Price100 = obj.Price100;
                objFromDb.Author = obj.Author;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.CategoryId = obj.CategoryId;
                if(obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}
