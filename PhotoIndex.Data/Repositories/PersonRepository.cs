using PhotoIndex.Data.Infrastructure;
using PhotoIndex.Model;

namespace PhotoIndex.Data.Repositories
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(IDatabaseFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IPersonRepository : IRepository<Person>
    {
    }
}