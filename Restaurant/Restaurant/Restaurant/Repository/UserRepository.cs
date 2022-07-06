using System.Linq;
using Restaurant.Model;

namespace Restaurant.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly DatabaseContext _dbContext;

        public UserRepository(DatabaseContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetByEmail(string email)
        {
            return _dbContext.Set<User>().FirstOrDefault(u => u.Email == email);
        }
    }
}