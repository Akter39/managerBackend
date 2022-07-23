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

using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace managerBackend.Controllers
{
    [Route("api/sign-in")]
    [ApiController]
    [Authorize]
    public class SignInController : ControllerBase
    {
        ApplicationContext db;
        IUserService<CurrentUser> UserManager;

        public SignInController(ApplicationContext context, IUserService<CurrentUser> userManager)
        {
            db = context;
            this.UserManager = userManager;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Auth([FromBody] SignInUser user)
        {
            if (ModelState.IsValid)
            {
                ConditionSignIn responce = new ConditionSignIn();
                User? sentUser = new();
                (responce, sentUser) = await SignInUser.VerificationSignIn(db, user, responce);
                if (responce.Successful)
                {
                    responce.CurrentUser = await UserManager.SignIn(responce.CurrentUser!, sentUser!, UserManager.IpAddress());
                    UserManager.setTokenCookie(responce.CurrentUser!.RefreshJwt);
                }
                return Ok(responce);
            }
            return BadRequest(ModelState);
        }

        [HttpPost("refresh-jwt")]
        [AllowAnonymous]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshToken = Request.Cookies["RefreshToken"];
            var responce = await UserManager.RefreshJwt(refreshToken!, UserManager.IpAddress());

            if (responce == null) return Unauthorized();

            UserManager.setTokenCookie(responce.RefreshJwt);

            return Ok(responce);
        }

        [HttpPost("revoke-jwt")]
        public async Task<IActionResult> RevokeJwt([FromBody] RevokeJwt token)
        {
            var jwt = token.Jwt ?? Request.Cookies["RefreshToken"];

            if (string.IsNullOrEmpty(jwt))
                return BadRequest(new { msg = "Jwt is required" });

            var responce = await UserManager.RevokeJwt(jwt, UserManager.IpAddress());
            if (!responce)
                return NotFound(new { msg = "Jwt not found" });
            return Ok(new { msg = "Jwt revoked" });
        }
    }
}
