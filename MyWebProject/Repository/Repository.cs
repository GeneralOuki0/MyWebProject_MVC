using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MyWebProject.Data;
using MyWebProject.Repository.IRepository;


namespace MyWebProject.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationdbContext _db;
        internal DbSet<T> dbSet;
        public Repository(ApplicationdbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
            
            _db.Products.Include(u => u.Category).Include(u => u.CategoryId); //here category will automatically be filled when we are trying to getall()
            _db.CartItems.Include(u => u.Product).Include(u => u.ProductId);
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter, String? IncludeProperties = null)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            if (!String.IsNullOrEmpty(IncludeProperties))
            {
                foreach (var includeProp in IncludeProperties.
                    Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(String? IncludeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if(!String.IsNullOrEmpty(IncludeProperties))
            {
                foreach(var includeProp in IncludeProperties.
                    Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }

    }
}

