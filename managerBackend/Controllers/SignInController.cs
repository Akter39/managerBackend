using managerBackend.ViewModels;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Linq;
using System.Text.RegularExpressions;

namespace managerBackend.Controllers
{
    [Route("api/sign-in")]
    [ApiController]
    public class SignInController : ControllerBase
    {
        ApplicationContext db;

        public class Condition
        {
            public bool successful { get; set; } = true;
            public bool invalidLoginFormat { get; set; } = false;
            public bool invalidPasswordFormat { get; set; } = false;
        }

        public SignInController(ApplicationContext context)
        {
            db = context;
        }

        [HttpPost]
        public IActionResult Post([FromBody] SignInUser user)
        {
            if (ModelState.IsValid)
            {
                Condition condition = new Condition();
                condition = VerificationSignIn(user, condition);
                if (condition.successful)
                {
                }
                return Ok(condition);
            }
            return BadRequest(ModelState);
        }
        private Condition VerificationSignIn(SignInUser user, Condition condition)
        {   
            if (!(Regex.IsMatch(user.userLogin, RegexConstants.userPhone) ||
                Regex.IsMatch(user.userLogin, RegexConstants.userEmail) ||
                Regex.IsMatch(user.userLogin, RegexConstants.userName))) 
            {
                condition.successful = false;
                condition.invalidLoginFormat = true;
            }   
            if (condition.successful)
{
                var sentUser = db.Users.FirstOrDefault(u => (u.userPhone == user.userLogin || u.userEmail == user.userLogin || u.userName == user.userLogin)
                && u.userPassword == user.userPassword);
                if (sentUser == null) condition.successful = false;
            }
            return condition;
        }
    }
}
