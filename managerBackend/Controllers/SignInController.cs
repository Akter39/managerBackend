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
        UserService userManager;

        public SignInController(ApplicationContext context, UserService userManager)
        {
            db = context;
            this.userManager = userManager;
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
                    await userManager.SignIn(responce.CurrentUser!, sentUser!, userManager.IpAddress());
                    userManager.setTokenCookie(responce.CurrentUser!.RefreshJwt);
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
            var responce = await userManager.RefreshJwt(refreshToken!, userManager.IpAddress());

            if (responce == null) return Unauthorized();

            userManager.setTokenCookie(responce.RefreshJwt);

            return Ok(responce);
        }

        [HttpPost("revoke-jwt")]
        public async Task<IActionResult> RevokeJwt([FromBody] RevokeJwt token)
        {
            var jwt = token.Jwt ?? Request.Cookies["RefreshToken"];

            if (string.IsNullOrEmpty(jwt))
                return BadRequest(new { msg = "Jwt is required" });

            var responce = await userManager.RevokeJwt(jwt, userManager.IpAddress());
            if (!responce)
                return NotFound(new { msg = "Jwt not found" });
            return Ok(new { msg = "Jwt revoked" });
        }
    }
}
