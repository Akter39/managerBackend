using managerBackend.Services;
using managerBackend.ViewModels;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace managerBackend.Controllers
{
    [Route("api/")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        ApplicationContext db;
        IUserService<CurrentUser> UserManager;
        public UsersController(ApplicationContext context, IUserService<CurrentUser> userManager)
        {
            db = context;
            UserManager = userManager;
        }

        [HttpGet("get/user/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            if(ModelState.IsValid)
            {
                UserInfo userInfo = await UserManager.GetUser(id);
                if (userInfo is not null) return Ok(userInfo);
                return BadRequest("User is not found");
            }
            return BadRequest();
        }
    }
}
