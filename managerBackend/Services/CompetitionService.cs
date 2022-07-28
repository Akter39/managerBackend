using managerBackend.Models;
using managerBackend.ViewModels;

using Microsoft.EntityFrameworkCore;

namespace managerBackend.Services
{
    public class CompetitionService: ICompetitionService
    {
        ApplicationContext db;
        IHttpContextAccessor HttpContextAccessor;
        public CompetitionService(ApplicationContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.HttpContextAccessor = httpContextAccessor;
            db = context;
        }

        public async Task NewCompetition(Competition competition)
        {
            int id = Int32.Parse(HttpContextAccessor.HttpContext.User.FindFirst("id").Value);
            User user = await db.Users.FirstOrDefaultAsync(u => u.Id == id);
            competition.User = user;
            db.Competitions.Add(competition);
            await db.SaveChangesAsync();
        }

        public async Task UpdateCompetition(Competition competition) {
            db.Competitions.Update(competition);
            await db.SaveChangesAsync();
        }

        public async Task DeleteCompetition(int id)
        {

        }

    }
    public static class CompetitionsServiceExtensions
    {
        public static void AddCompetitionManeger<TImplementation>(this IServiceCollection services)
            where TImplementation : class, ICompetitionService
        {
            services.AddScoped<ICompetitionService, TImplementation>();
        }
    }
}
