using Restaurant.Model;
using Restaurant.Repository;

namespace Restaurant.Repository
{
    public interface IUserRepository : IGenericRepository<User>
    { 
        public User GetByEmail(string email);

    }
}