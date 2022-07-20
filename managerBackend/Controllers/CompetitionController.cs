using managerBackend.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace managerBackend.Controllers
{
    [Route("api/competition")]
    [ApiController]
    [Authorize]
    public class CompetitionController : ControllerBase
    {
        public class Tests
        {
            public string comp { get; set; }
        }
        ApplicationContext db;
        public CompetitionController(ApplicationContext context)
        {
            this.db = context;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Post([FromBody] Tests competition)
        {
            if (ModelState.IsValid)
            {
                return Ok(competition);
            }
            return BadRequest();
        }
    }
}
