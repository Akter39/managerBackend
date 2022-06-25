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
            public bool Successful { get; set; } = true;
            public bool NameBusy { get; set; } = false;
            public bool NicknameBusy { get; set; } = false;
            public bool EmailBusy { get; set; } = false;
            public bool PhoneBusy { get; set; } = false;
            public bool NotMatchPasswords { get; set; } = false;
            public bool MatchName { get; set; } = false;
            public bool InvalidNameFormat { get; set; } = false;
            public bool InvalidNicknameFormat { get; set; } = false;
            public bool InvalidEmailFormat { get; set; } = false;
            public bool InvalidPhoneFormat { get; set; } = false;
            public bool InvalidPasswordFormat { get; set; } = false;
            public bool InvalidCityFormat { get; set; } = false;
            public bool InvalidOrganizationFormat { get; set; } = false;
        }
        public SignUpController(ApplicationContext context)
        {
            db = context;
        }
        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            if (ModelState.IsValid)
            {
        Condition condition = new Condition();
        condition = VerificationUser(user, condition);
                if (condition.Successful) {
                    Role? roleUser = db.Roles.FirstOrDefault(c => c.Name == "User");
                    if (roleUser != null)
                    {
                        user.Roles.Add(roleUser);
                        db.Users.Add(user);
                        db.SaveChanges();
                    }
                    else
                        return BadRequest("Server Error");
                }
                return Ok(condition);
                //return Ok(Results.Json(condition));
            }
            return BadRequest(ModelState);
        }

        private Condition VerificationUser(User user, Condition condition)
            {
            if (db.Users.Any(u => u.UserName == user.UserName)) { 
                condition.NameBusy = true;
                condition.Successful = false;
            }
            if (db.Users.Any(u => u.UserNickname == user.UserNickname))
            {
                condition.NicknameBusy = true;
                condition.Successful = false;
            }
            if (db.Users.Any(u => u.UserEmail == user.UserEmail)) { 
                condition.EmailBusy = true;
                condition.Successful = false;
            }
            if (db.Users.Any(u => u.UserPhone == user.UserPhone)) { 
                condition.PhoneBusy = true;
                condition.Successful = false;
            }

            if (user.UserPassword != user.UserConfirmPassword) { 
                condition.NotMatchPasswords = true;
                condition.Successful = false;
            }
            if (user.UserNickname == user.UserName)
            {
                condition.MatchName = true;
                condition.Successful = false;
            }
            if (!Regex.IsMatch(user.UserName, RegexConstants.userName)) { 
                condition.InvalidNameFormat = true;
                condition.Successful = false;
            }
            if(!Regex.IsMatch(user.UserNickname, RegexConstants.userName))
            {
                condition.InvalidNicknameFormat = true;
                condition.Successful = false;
            }
            if (!Regex.IsMatch(user.UserPhone, RegexConstants.userPhone)) { 
                condition.InvalidPhoneFormat = true;
                condition.Successful = false;
            }
            if (!Regex.IsMatch(user.UserPassword, RegexConstants.userPassword)) { 
                condition.InvalidPasswordFormat = true;
                condition.Successful = false;
            }
            if (!Regex.IsMatch(user.UserEmail, RegexConstants.userEmail, RegexOptions.IgnoreCase)) { 
                condition.InvalidEmailFormat = true;
                condition.Successful = false;
            }
            if (!Regex.IsMatch(user.UserCity, RegexConstants.userCity)) { 
                condition.InvalidCityFormat = true;
                condition.Successful = false;
            }
            if (!Regex.IsMatch(user.UserOrganization, RegexConstants.userOrganization)) { 
                condition.InvalidOrganizationFormat = true;
                condition.Successful = false;
            }

            return condition;
        }
    }
}
