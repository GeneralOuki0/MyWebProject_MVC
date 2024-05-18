using System.Linq.Expressions;

namespace MyWebProject.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(String? IncludeProperties = null);
        T Get(Expression<Func<T,bool>> filter, String? IncludeProperties = null);
        
        void Remove(T entity);
        void Add(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}
