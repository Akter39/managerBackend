using managerBackend.Services;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace managerBackend.Controllers
{
    [Route("api/language")]
    [ApiController]
    [Authorize]
    public class LanguageController : ControllerBase
    {
        ILanguageService languageService;
        public LanguageController(ILanguageService languageService)
        {
            this.languageService = languageService;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult SetLanguage()
        {
            if (languageService.SetLanguage()) return Ok();
            return StatusCode(412);
        }
    }
}
