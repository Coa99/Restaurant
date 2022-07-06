using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Restaurant.Authorization;
using Restaurant.DTO;
using Restaurant.Model;
using Restaurant.Service;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Restaurant.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IJwtUtils _jwtUtils;
        private readonly IUserService _userService;

        public UserController(IUserService userService, IJwtUtils jwtUtils)
        {
            _userService = userService;
            _jwtUtils = jwtUtils;
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public IActionResult Login(LoginDTO model)
        {
            var user = _userService.GetByEmail(model.Username);

            // validate
            if (user == null || !BCryptNet.Verify(model.Password, user.Password))
                throw new ApplicationException("Username or password is incorrect");
            
            
            // authentication successful so generate jwt token
            var jwtToken = _jwtUtils.GenerateJwtToken(user);
            return Ok(new LoginResponseDTO(user, jwtToken));
        }

        [HttpGet]
        [Authorize(Role.Admin)]
        public IEnumerable<User> GetAll()
        {
            return _userService.GetAllUsers();
        }

        [HttpGet]
        [Route("{id}")]
        public User GetById(int id)
        {
            return _userService.GetUser(id);
        }

        [HttpPost]
        [AllowAnonymous]
        public User RegisterUser(User user)
        {
            return _userService.RegisterUser(user);
        }

        [HttpPut]
        [AllowAnonymous]
        public User Update(User user)
        {
            return _userService.Update(user);
        }
    }
}
