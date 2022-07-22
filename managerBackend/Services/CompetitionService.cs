using managerBackend.Models;

namespace managerBackend.Services
{
    public class CompetitionService
    {
        ApplicationContext db;
        public CompetitionService(ApplicationContext context)
        {
            db = context;
        }

        public async Task<bool> NewCompetition(Competition competition)
        {
            db.Competitions.Add(competition);
            await db.SaveChangesAsync();
            return true;
        }
    }
    public static class CompetitionsServiceExtensions
    {
        public static void AddCompetitionManeger(this IServiceCollection services)
        {
            services.AddScoped<UserService>();
        }
    }
}
