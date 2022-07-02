using managerBackend.Models;
using managerBackend.ViewModels;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
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

        public SignInController(ApplicationContext context)
        {
            db = context;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] SignInUser user)
        {
            if (ModelState.IsValid)
            {
                ConditionSignIn condition = new ConditionSignIn();
                User? sentUser = null;
                (condition, sentUser) = await VerificationSignIn(user, condition);
                if (condition.Successful)
                {
                    List<string> roles = new List<string>();
                    foreach (var role in sentUser.Roles)
                    {
                        roles.Add(role.Name);
                    }
                     condition.CurrentUser = new CurrentUser() { 
                        Id = sentUser!.Id,
                        Nickname = sentUser.UserNickname,
                        Organization = sentUser.UserOrganization,
                        City = sentUser.UserCity,
                        Roles = roles};

                    var claims = new List<Claim>();

                    claims.Add(new Claim("username", sentUser!.UserName));
                    claims.Add(new Claim("nickname", sentUser!.UserNickname));

                    foreach(var role in sentUser!.Roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role.Name));
                    }

                    var jwt = new JwtSecurityToken(
                        issuer: AuthOptions.ISSUER,
                        audience: AuthOptions.AUDIENCE,
                        claims: claims,
                        expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                        signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
                    condition.CurrentUser!.Token = new JwtSecurityTokenHandler().WriteToken(jwt);
                }
                return Ok(condition);
            }
            return BadRequest(ModelState);
        }
        private async Task<(ConditionSignIn, User?)> VerificationSignIn(SignInUser user, ConditionSignIn condition)
        {   
            User? sentUser = null;

            if(Regex.IsMatch(user.UserLogin, RegexConstants.userPhone)) sentUser = await db.Users.Include(u => u.Roles).FirstOrDefaultAsync(u =>
                u.UserPhone == user.UserLogin && u.UserPassword == user.UserPassword);
            else
                if(Regex.IsMatch(user.UserLogin, RegexConstants.userEmail)) sentUser = await db.Users.Include(u => u.Roles).FirstOrDefaultAsync(u =>
                    u.UserEmail == user.UserLogin && u.UserPassword == user.UserPassword);
            else
                if (Regex.IsMatch(user.UserLogin, RegexConstants.userName)) sentUser = await db.Users.Include(u => u.Roles).FirstOrDefaultAsync(u =>
                    u.UserName == user.UserLogin && u.UserPassword == user.UserPassword);
            else
            {
                condition.Successful = false;
                condition.InvalidLoginFormat = true;
            }

            if (sentUser == null)
            {
                condition.Successful = false;
                condition.InvalidSignIn = true;
            }

            return (condition, sentUser);
        }
    }
}
