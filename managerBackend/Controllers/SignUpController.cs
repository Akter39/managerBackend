using managerBackend.Models;
using managerBackend.ViewModels;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Text.RegularExpressions;

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
        public async Task<IActionResult> Post([FromBody]User user)
        {
            if (ModelState.IsValid)
            {
        ConditionSignUp condition = new ConditionSignUp();
        condition = await VerificationUser(user, condition);
                if (condition.Successful) {
                    Role? roleUser = await db.Roles.FirstOrDefaultAsync(c => c.Name == "User");
                    if (roleUser != null)
                    {
                        user.Roles.Add(roleUser);
                        db.Users.Add(user);
                        await db.SaveChangesAsync();
                    }
                    else
                        return BadRequest("Server Error");
                }
                return Ok(condition);
            }
            return BadRequest(ModelState);
        }

        private async Task<ConditionSignUp> VerificationUser(User user, ConditionSignUp condition)
            {
            if (await db.Users.AnyAsync(u => u.UserName == user.UserName)) { 
                condition.NameBusy = true;
                condition.Successful = false;
            }
            if (await db.Users.AnyAsync(u => u.UserNickname == user.UserNickname))
            {
                condition.NicknameBusy = true;
                condition.Successful = false;
            }
            if (await db.Users.AnyAsync(u => u.UserEmail == user.UserEmail)) { 
                condition.EmailBusy = true;
                condition.Successful = false;
            }
            if (await db.Users.AnyAsync(u => u.UserPhone == user.UserPhone)) { 
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
