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
            List<Distance> distances = new();
            DistanceStyleConstants distStyleConst = new();
            GenderConstants genderConst = new();
            int i = 0;
            foreach (var dist in distStyleConst)
            {
                foreach (var gender in genderConst)
                {
                    string[] s = dist.Split('.');
                    distances.Add(new Distance(++i, s[0], s[1], gender));
                }
            }
            if (ModelState.IsValid)
            {
                ConditionCompetition responce = await competition.VerificationCompetition(db);
                if (responce.Successful)
                {
                    //await CompetitionService.NewCompetition(competition);
                }
                return Ok("Competition successfully created");
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

                await CompetitionService.UpdateCompetition(competition);
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
                    await CompetitionService.DeleteCompetition(id); 
                }
                return Ok(responce);
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
