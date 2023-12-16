using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_MySQL.Models;
using ASP.NET_MySQL.Services;
using ASP.NET_MySQL.Util;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_MySQL.Controllers
{
    [ApiController]
    [Route("/")]
    public class UserController : Controller
    {

        private readonly UserService _userService;

        public UserController(UserService us)
        {
            _userService = us;
        }

        //https://localhost:7027/
        [HttpGet(Name = "home")]
        public String Index()
        {
            return "Hello";
        }

        //https://localhost:7027/user
        [HttpPost("user",Name = "user")]
        public User CreateUser()
        {
            int fakeId = DateTime.Now.Millisecond % 10000;

            var user = new User(fakeId,"hello", "world");
            _userService.CreateUser(user);
            Console.WriteLine("user created");
            return user;
        }

        [HttpGet("user")]
        public IEnumerable<User> GetAllUser()
        {
            var users = _userService.GetUsers();
            return users;
        }

        [HttpPut("user")]
        public IActionResult UpdateUser(int id, [FromBody] User user)
        {
            user.Id = id;
            _userService.UpdateUser(user);
            return Ok();
        }

        [HttpDelete("user")]
        public IActionResult DeleteUser(int id)
        {
            _userService.DeleteUser(id);
            return Ok();
        }
    }
}

