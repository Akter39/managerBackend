using managerBackend.Models;
using managerBackend.ViewModels;

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
        public CompetitionController(ApplicationContext context, CompetitionService competitionService)
        {
            this.db = context;
        }

        [Authorize(Roles = "MainAdmin, Admin, VipUser")]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Competition competition)
        {
            if (ModelState.IsValid)
            {
                ConditionCompetition responce = await Competition.VerificationCompetition(db, competition);
                if (responce.Successful)
                {
                    competitionS
                }
                return Ok(competition);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            if (ModelState.IsValid)
            {
                return Ok(id);
            }
            return BadRequest();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                return Ok(page);
            }
            return BadRequest();
        }

        [HttpGet("calendar/{page}")]
        public async Task<IActionResult> GetCalendar(int page)
        {
            if (ModelState.IsValid)
            {
                return Ok(page);
            }
            return BadRequest();
        }

        [HttpGet("current/{page}")]
        public async Task<IActionResult> GetCurrent(int page)
        {
            if (ModelState.IsValid)
            {
                return Ok(page);
            }
            return BadRequest();
        }

        [HttpGet("archive/{page}")]
        public async Task<IActionResult> GetArchive(int page)
        {
            if (ModelState.IsValid)
            {
                return Ok(page);
            }
            return BadRequest();
        }

        [HttpGet("search/{page}")]
        public async Task<IActionResult> GetSearch(int page)
        {
            if (ModelState.IsValid)
            {
                return Ok(page);
            }
            return BadRequest();
        }


    }
}
