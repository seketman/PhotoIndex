using PhotoIndex.Data.Infrastructure;
using PhotoIndex.Model;

namespace PhotoIndex.Data.Repositories
{
    public class PhotoRepository : RepositoryBase<Photo>, IPhotoRepository
    {
        public PhotoRepository(IDatabaseFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IPhotoRepository : IRepository<Photo>
    {
    }
}