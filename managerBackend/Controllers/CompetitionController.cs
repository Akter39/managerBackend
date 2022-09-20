using managerBackend.Constants;
using managerBackend.Helpers;
using managerBackend.Models;
using managerBackend.Services;
using managerBackend.ViewModels;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;

namespace managerBackend.Controllers
{
    [Route("api/competition")]
    [ApiController]
    [Authorize]
    public class CompetitionController : ControllerBase
    {
        ApplicationContext db;
        ICompetitionService CompetitionService;
        public CompetitionController(ApplicationContext context, ICompetitionService competitionService)
        {
            this.CompetitionService = competitionService;
            this.db = context;
        }

        [Authorize(Roles = "MainAdmin, Admin, VipUser")]
        [HttpPost("create")]
        public async Task<IActionResult> Create(Competition competition)
        {
            if (ModelState.IsValid)
            {
                ConditionCompetition responce = await competition.VerificationCompetition(db);
                if (responce.Successful)
                {
                    await CompetitionService.New(competition);
                    return Ok("Competition successfully created");
                }
                return BadRequest("Error verification competition");
            }
            return BadRequest(ModelState);
        }

        [HttpPut("edit")]
        public async Task<IActionResult> Edit(Competition competition)
        {
            if (ModelState.IsValid)
            {
                var userId = HttpContext.User.FindFirst("id");
                ConditionCompetition responce = await competition.VerificationCompetition(db, userId: Int32.Parse(userId.Value));

                await CompetitionService.Update(competition);
                return Ok(responce);
            }
            return BadRequest();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                Competition competition = new();
                var userId = HttpContext.User.FindFirst("id");
                ConditionCompetition responce = await competition.VerificationCompetition(db, true, Int32.Parse(userId.Value));
                if (responce.Successful)
                {
                    await CompetitionService.Delete(id); 
                }
                return Ok(responce);
            }
            return BadRequest();
        }

        [HttpGet("upcoming")]
        public async Task<IActionResult> GetUpcoming()
        {
            if (ModelState.IsValid)
            {
                List<Competition> responce = await CompetitionService.Upcoming();
                if (responce is null) return StatusCode(406, "Not upcoming competitions found");
                return Ok(responce.ToArray());
            }
            return BadRequest();
        }

        [HttpGet("current")]
        public async Task<IActionResult> GetCurrent()
        {
            if (ModelState.IsValid)
            {
                List<Competition> responce = await CompetitionService.Current();
                if (responce is null) return StatusCode(406, "Not upcoming competitions found");
                return Ok(responce.ToArray());
            }
            return BadRequest();
        }

        [HttpGet("archive")]
        public async Task<IActionResult> GetArchive()
        {
            if (ModelState.IsValid)
            {
                List<Competition> responce = await CompetitionService.Archive();
                if (responce is null) return StatusCode(406, "Not upcoming competitions found");
                return Ok(responce.ToArray());
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
