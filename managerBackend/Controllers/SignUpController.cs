using managerBackend.Models;
using managerBackend.Services;
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
        UserService userManager;

        public SignUpController(ApplicationContext context, UserService userManager)
        {
            db = context;
            this.userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]User user)
        {
            if (ModelState.IsValid)
            {
                ConditionSignUp responce = await user.VerificationUser(db, user);
                if (responce.Successful) {
                    if (await userManager.NewUser(user, "User"))
                    {
                        return Ok(responce);
                    }
                    else
                        return BadRequest("Server's Error");
                }
                return Ok(responce);
            }
            return BadRequest(ModelState);
        }
    }
}
