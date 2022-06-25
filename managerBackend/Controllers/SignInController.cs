using managerBackend.ViewModels;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace managerBackend.Controllers
{
    [Route("api/sign-in")]
    [ApiController]
    [Authorize]
    public class SignInController : ControllerBase
    {
        ApplicationContext db;

        public class Condition
        {
            public bool successful { get; set; } = true;
            public bool invalidSignIn { get; set; } = false;
            public bool invalidLoginFormat { get; set; } = false;
            public bool invalidPasswordFormat { get; set; } = false;
        }

        public SignInController(ApplicationContext context)
        {
            db = context;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] SignInUser user)
        {
            if (ModelState.IsValid)
            {
                Condition condition = new Condition();
                condition = VerificationSignIn(user, condition);
                if (condition.successful)
                {
                    var claims = new List<Claim>
                    {

                    };
                }
                return Ok(condition);
            }
            return BadRequest(ModelState);
        }
        private Condition VerificationSignIn(SignInUser user, Condition condition)
        {   
            if (!(Regex.IsMatch(user.UserLogin, RegexConstants.userPhone) ||
                Regex.IsMatch(user.UserLogin, RegexConstants.userEmail) ||
                Regex.IsMatch(user.UserLogin, RegexConstants.userName))) 
            {
                condition.successful = false;
                condition.invalidLoginFormat = true;
            }   
            if (condition.successful)
{
                var sentUser = db.Users.FirstOrDefault(u => (u.UserPhone == user.UserLogin || u.UserEmail == user.UserLogin || u.UserName == user.UserLogin)
                && u.UserPassword == user.UserPassword);
                if (sentUser == null) 
                {
                    condition.successful = false;
                    condition.invalidSignIn = true;
                }
            }
            return condition;
        }
    }
}
