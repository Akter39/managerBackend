using managerBackend.Models;
using managerBackend.ViewModels;

namespace managerBackend.Services
{
    public interface ICompetitionService
    {
        public Task New(Competition competitionm);
        public Task Update(Competition competition);
        public Task Delete(int id);

        public Task<List<Competition>> Upcoming();
        public Task<List<Competition>> Current();
        public Task<List<Competition>> Archive();
    }
}
