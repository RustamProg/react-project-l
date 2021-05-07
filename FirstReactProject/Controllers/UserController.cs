using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstReactProject.Models;
using FirstReactProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace FirstReactProject.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : Controller
    {
        private readonly IUsersRepository _usersRepository;
        
        public UserController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        
        [HttpGet("users_list")]
        public ActionResult<List<User>> GetAllUsers()
        {
            var result = _usersRepository.GetAllUsers();
            return result;
        }

        [HttpGet("user_by_id")]
        public ActionResult<User> GetUserById(int id)
        {
            var result = _usersRepository.GetUserById(id);
            return result;
        }

        [HttpGet("users_by_location")]
        public ActionResult<List<User>> GetUsersByLocation(string country, string city)
        {
            var result = _usersRepository.GetByLocation(country, city);
            return result;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(User user)
        {
            await _usersRepository.InsertUser(user);
            return Ok(user);
        }
        
    }
}