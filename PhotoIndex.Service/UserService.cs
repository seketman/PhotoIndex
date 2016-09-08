using System.Linq;

using PhotoIndex.Data.Repositories;
using PhotoIndex.Data.Infrastructure;
using PhotoIndex.Model;

namespace PhotoIndex.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;
        public UserService(IUserRepository userRepository,IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }
     

        public ApplicationUser RegisterUser(ApplicationUser user)
        {
            user =userRepository.Add(user);
            SaveChanges();
            return user;
        }

        public ApplicationUser GetUserByEmail(string email)
        {
           var user = userRepository.GetMany(u => u.Email == email).FirstOrDefault();
           return user;
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }

    }

    public interface IUserService
    {
        ApplicationUser GetUserByEmail(string email);
        ApplicationUser RegisterUser(ApplicationUser user);

    }
}
