using PhotoIndex.Data.Infrastructure;
using PhotoIndex.Model;

namespace PhotoIndex.Data.Repositories
{
    public class FaceRepository : RepositoryBase<Face>, IFaceRepository
    {
        public FaceRepository(IDatabaseFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IFaceRepository : IRepository<Face>
    {
    }
}