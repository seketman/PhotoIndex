using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PhotoIndex.Data.Infrastructure;
using PhotoIndex.Model;

namespace PhotoIndex.Data.Repositories
{
    public class UserRepository : RepositoryBase<ApplicationUser>, IUserRepository
    {

        public UserRepository(IDatabaseFactory dbFactory): base(dbFactory)
        {

        } 
    }

    public interface IUserRepository : IRepository<ApplicationUser>
    { 
    }
}
