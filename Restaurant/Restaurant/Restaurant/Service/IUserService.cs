using System.Collections.Generic;
using Restaurant.Model;

namespace Restaurant.Service
{
    public interface IUserService
    {
        public User GetUser(int id);
        public IEnumerable<User> GetAllUsers();
        public User RegisterUser(User user);
        public User Update(User user);
        public User GetByEmail(string email);
    }
}