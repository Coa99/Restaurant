using System.Collections.Generic;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Restaurant.Model;
using Restaurant.Repository;
using Restaurant.Service;


namespace Restaurant.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
        }

        public User GetByEmail(string username)
        {
            return _userRepository.GetByEmail(username);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public User GetUser(int id)
        {
            return _userRepository.GetById(id);
        }

        public User RegisterUser(User user)
        {
            User emailTaken = _userRepository.GetByEmail(user.Email);
            if (emailTaken != null) return null;
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            return _userRepository.Insert(user);
        }

        public User Update(User user)
        {
            User oldUser = _userRepository.GetByEmail(user.Email);
            if (oldUser == null) return null;
            user.Password = user.Password.IsNullOrEmpty() ? oldUser.Password : BCrypt.Net.BCrypt.HashPassword(user.Password);
            return _userRepository.Update(user);
        }
    }
}