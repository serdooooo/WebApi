using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController()
        {

        }
        [HttpGet]
        public List<User> Get()
        {
            List<User> users = new List<User>();
            users.Add(new User { Email = "serdar@gmail.com", Password = "1234" });
            users.Add(new User { Email = "ali@gmail.com", Password = "3256" });
            users.Add(new User { Email = "veli@gmail.com", Password = "8975" });
            users.Add(new User { Email = "ahmet@gmail.com", Password = "4676879" });
            users.Add(new User { Email = "mehmet@gmail.com", Password = "23544" });
            return users;
        }
    }
}
