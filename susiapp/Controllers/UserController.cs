using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace susi_app.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        private static IList<User> Users = new List<User>() {
            new User() { Username = "wellintonmonge", Email= "wellintonmonge@outlook.com", Password = "123abc" },
            new User() { Username = "wellintonmonge2",Email= "wellintonmonge@outlook.com", Password = "123abc" },
            new User() { Username = "wellintonmonge3",Email= "wellintonmonge@outlook.com", Password = "123abc" },
            new User() {  Username = "wellintonmonge4",Email= "wellintonmonge@outlook.com", Password = "123abc" },

        };

        [HttpGet("[action]")]
        public User GetUser(String username)
        {
            var result = Users.Where(x => x.Username == username).First();
            
            return result;
        }

        public class User
        {
            
            public string Username { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }

            public override bool Equals(object obj)
            {
                var user = obj as User;
                return user != null &&
                       Username == user.Username &&
                       Email == user.Email &&
                       Password == user.Password;
            }
        }
    }
}
