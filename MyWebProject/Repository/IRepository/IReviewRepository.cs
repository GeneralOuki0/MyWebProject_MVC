using MyWebProject.Models;

namespace MyWebProject.Repository.IRepository
{
    public interface IReviewRepository : IRepository<Review>
    {
        void Update(Review obj);

    }
}