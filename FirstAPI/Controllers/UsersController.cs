using FirstAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        public static User[] Users()
        {
            User[] user = new User[3];

            user[0] = new User { UserName = "Kashem", Email = "kashem@gmail.com", Password = "kashem123" };
            user[1] = new User { UserName = "Hashem", Email = "hashem@gmail.com", Password = "hashem123" };
            user[2] = new User {UserName= "Rohim", Email="rohim@gmail.com", Password="rohim123" };

            return user;
        }

        [HttpGet]
        public ActionResult GetAllUsers()
        {
            var users = Users();

            var allUsers = users.Select(user=> new UserData { UserName = user.UserName, Email= user.Email});

            return Ok(allUsers);
             
        }

        [HttpPost]
        public ActionResult PostIsUser([FromBody] IsUser data )
        {
            foreach (var user in Users())
            {
                if(data.Email == user.Email)
                {
                    if(user.Password == data.Password)
                    {
                        return Ok("Valid User");
                    }
                    else
                    {
                        return BadRequest("InValid User");
                    }
                }
            }

            return BadRequest();
        }

        [HttpPut]
        public ActionResult UpdateUserName([FromBody] UserData data)
        {

            string UpdateName = data.UserName;

            
            
            foreach (var user in Users())
            {
                if(user.Email == data.Email)
                {
                    user.UserName = UpdateName;

                    Console.WriteLine("update user name "+ user.UserName);

                    return Ok("UserName Updated successfully");
                }
            }


            return BadRequest();
        }

    }
}
