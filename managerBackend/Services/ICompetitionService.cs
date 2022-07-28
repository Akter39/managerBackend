using managerBackend.Models;
using managerBackend.ViewModels;

namespace managerBackend.Services
{
    public interface ICompetitionService
    {
        public Task NewCompetition(Competition competitionm);
        public Task UpdateCompetition(Competition competition);
        public Task DeleteCompetition(int id);
    }
}
