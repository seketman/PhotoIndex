using PhotoIndex.Data.Infrastructure;
using PhotoIndex.Model;

namespace PhotoIndex.Data.Repositories
{
    public class ResourceRepository : RepositoryBase<Resource>, IResourceRepository
    {
        public ResourceRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
          
        }
    }

    public interface IResourceRepository : IRepository<Resource>
    {
    }
}
