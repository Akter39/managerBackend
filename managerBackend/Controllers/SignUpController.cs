using managerBackend.Models;

using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace managerBackend.Controllers
{
    [Route("api/sign-up")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        ApplicationContext db;
        public SignUpController(ApplicationContext context)
        {
            db = context;

        }
        [HttpPost]
        public IActionResult Post(User user)
        {
            if(ModelState.IsValid)
            {
                if (!db.Users.Any(u=>u.userName == user.userName))
                {
                    db.Users.AddAsync(user);
                    db.SaveChangesAsync();
                }
            }
            return BadRequest(ModelState);
            /*foreach (var _user in typeof(User).GetProperties())
            {
                //Console.WriteLine(_user.Name, _user.GetValue(user));
                Console.WriteLine("{0}: {1}", _user.Name, _user.GetValue(user));
            }*/
        }
    }
}
