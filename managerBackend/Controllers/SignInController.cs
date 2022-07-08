using managerBackend.Models;
using managerBackend.Services;
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
        UserManager userManager;

        public SignInController(ApplicationContext context, UserManager userManager)
        {
            db = context;
            this.userManager = userManager;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] SignInUser user)
        {
            if (ModelState.IsValid)
            {
                ConditionSignIn condition = new ConditionSignIn();
                User? sentUser = null;
                (condition, sentUser) = await SignInUser.VerificationSignIn(db, user, condition);
                if (condition.Successful)
                {
                    userManager.SignIn(condition, sentUser);
                }
                return Ok(condition);
            }
            return BadRequest(ModelState);
        }
    }
}
