using managerBackend.Models;
using managerBackend.ViewModels;

using Microsoft.AspNetCore.Mvc;

using System.Text.RegularExpressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace managerBackend.Controllers
{
    [Route("api/sign-up")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        ApplicationContext db;
        public class Condition
        {
            public bool successful { get; set; } = true;
            public bool nameBusy { get; set; } = false;
            public bool emailBusy { get; set; } = false;
            public bool phoneBusy { get; set; } = false;
            public bool notMatchPasswords { get; set; } = false;
            public bool invalidNameFormat { get; set; } = false;
            public bool invalidEmailFormat { get; set; } = false;
            public bool invalidPhoneFormat { get; set; } = false;
            public bool invalidPasswordFormat { get; set; } = false;
            public bool invalidCityFormat { get; set; } = false;
            public bool invalidOrganizationFormat { get; set; } = false;
        }
        public SignUpController(ApplicationContext context)
        {
            db = context;
        }
        [HttpPost]
        public IActionResult Post([FromBody]NewUser user)
        {
            if (ModelState.IsValid)
            {
        Condition condition = new Condition();
        condition = VerificationUser(user, condition);
                if (condition.successful) {
                    db.Users.Add(user);
                    db.SaveChanges();
                }
                return Ok(condition);
            }
            return BadRequest(ModelState);
        }

        private Condition VerificationUser(NewUser user, Condition condition)
            {
            if (db.Users.Any(u => u.userName == user.userName)) { 
                condition.nameBusy = true;
                condition.successful = false;
            }
            if (db.Users.Any(u => u.userEmail == user.userEmail)) { 
                condition.emailBusy = true;
                condition.successful = false;
            }
            if (db.Users.Any(u => u.userPhone == user.userPhone)) { 
                condition.phoneBusy = true;
                condition.successful = false;
            }

            if (user.userPassword != user.userConfirmPassword) { 
                condition.notMatchPasswords = true;
                condition.successful = false;
            }
            if (!Regex.IsMatch(user.userName, RegexConstants.userName)) { 
                condition.invalidNameFormat = true;
                condition.successful = false;
            }
            if (!Regex.IsMatch(user.userPhone, RegexConstants.userPhone)) { 
                condition.invalidPhoneFormat = true;
                condition.successful = false;
            }
            if (!Regex.IsMatch(user.userPassword, RegexConstants.userPassword)) { 
                condition.invalidPasswordFormat = true;
                condition.successful = false;
            }
            if (!Regex.IsMatch(user.userEmail, RegexConstants.userEmail, RegexOptions.IgnoreCase)) { 
                condition.invalidEmailFormat = true;
                condition.successful = false;
            }
            if (!Regex.IsMatch(user.userCity, RegexConstants.userCity)) { 
                condition.invalidCityFormat = true;
                condition.successful = false;
            }
            if (!Regex.IsMatch(user.userOrganization, RegexConstants.userOrganization)) { 
                condition.invalidOrganizationFormat = true;
                condition.successful = false;
            }

            return condition;
        }
    }
}
