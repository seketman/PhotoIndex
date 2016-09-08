using PhotoIndex.Data.Infrastructure;
using PhotoIndex.Model;

namespace PhotoIndex.Data.Repositories
{
    public class LocationRepository : RepositoryBase<Location>, ILocationRepository
    {
        public LocationRepository(IDatabaseFactory dbFactory): base(dbFactory)
        {
        }
    }

    public interface ILocationRepository : IRepository<Location>
    {
    }
}
