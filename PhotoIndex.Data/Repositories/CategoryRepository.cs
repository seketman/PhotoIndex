using PhotoIndex.Data.Infrastructure;
using PhotoIndex.Model;

namespace PhotoIndex.Data.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IDatabaseFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface ICategoryRepository : IRepository<Category>
    {
    }
}
