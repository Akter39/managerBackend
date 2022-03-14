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
            public bool successful = true;
            public bool nameBusy = false;
            public bool emailBusy = false;
            public bool phoneBusy = false;
            public bool notMatchPasswords = false;
            public bool invalidNameFormat = false;
            public bool invalidEmailFormat = false;
            public bool invalidPhoneFormat = false;
            public bool invalidPasswordFormat = false;
            public bool invalidCityFormat = false;
            public bool invalidOrganizationFormat = false;
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
                return Ok(new {
                    successful = condition.successful,
                    nameBusy = condition.nameBusy,
                    emailBusy = condition.emailBusy,
                    phoneBusy = condition.phoneBusy,
                    notMatchPasswords = condition.notMatchPasswords,
                    invalidNameFormat = condition.invalidNameFormat,
                    invalidEmailFormat = condition.invalidEmailFormat,
                    invalidPhoneFormat = condition.invalidPhoneFormat,
                    invalidPasswordFormat = condition.invalidPasswordFormat,
                    invalidCityFormat = condition.invalidCityFormat,
                    invalidOrganizationFormat = condition.invalidOrganizationFormat
                });
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
