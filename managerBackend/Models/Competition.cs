using managerBackend.Constants;
using managerBackend.Helpers;
using managerBackend.ViewModels;

using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace managerBackend.Models
{
    public class Competition
    {
        [BindNever]
        public int Id { get; set; }
        [MaxLength(64)]
        public string Name { get; set; }
        public DateTime StartCompetition { get; set; }
        [BindingBehavior(BindingBehavior.Optional)]
        public DateTime EndCompetition { get; set; }
        public int PoolLength { get; set; }
        public int PoolLanes { get; set; }
        [NotMapped]
        public int BidDay { get; set; }
        [BindNever]
        public DateTime BidDate { 
            get { return StartCompetition.AddDays(-BidDay); }
        }
        public int Contribution { get; set; }
        public bool Individual { get; set; }
        public bool InvitOnly { get; set; }
        public int MaxMembers { get; set; }
        public int MaxComands { get; set; }
        public int MaxComandMembers { get; set; }
        [BindNever]
        public int CurrentMembers { get; set; }
        [BindNever]
        public int CurrentComands { get; set; }
        public List<Distance> Distances { get; set; } = new ();
        [BindNever]
        public int UserId { get; set; }
        [BindNever]
        public User User { get; set; }

        public async static Task<ConditionCompetition> VerificationCompetition(ApplicationContext db, Competition competition, int userId = -1)
        {
            ConditionCompetition responce = new();
            if (!Regex.IsMatch(competition.Name, CompetitionConsts.Name))
            {
                responce.Successful = false;
                responce.InvalidName = true;
            }
            if (!typeof(PoolConsts.Length).GetPublicContants<int>().Contains(competition.PoolLength))
            {
                responce.Successful = false;
                responce.InvalidPoolLength = true;
            }
            if (!typeof(PoolConsts.Lanes).GetPublicContants<int>().Contains(competition.PoolLanes))
            {
                responce.Successful = false;
                responce.InvalidPoolLanes = true;
            }
            if (competition.Contribution < 0)
            {
                responce.Successful = false;
                responce.InvalidContributuon = true;
            }
            if (competition.StartCompetition.AddDays(-competition.BidDay) < DateTime.Now)
            {
                responce.Successful = false;
                responce.InvalidStartDate = true;
            }
            if (competition.EndCompetition.Subtract(competition.StartCompetition).Days > 7)
            {
                responce.Successful = false;
                responce.InvalidEndDate = true;
            }
            if (competition.EndCompetition < competition.StartCompetition)
            {
                responce.Successful = false;
                responce.InvalidStartDate = true;
                responce.InvalidEndDate = true;
            }
            if (competition.BidDay < 2 || competition.BidDay > 30)
            {
                responce.Successful = false;
                responce.InvalidBid = true;
            }
            if (competition.MaxMembers > 0 && competition.MaxComands > 0 && competition.MaxComandMembers > 0)
            {
                if ((competition.MaxComands * competition.MaxComandMembers) > competition.MaxMembers)
                {
                    responce.Successful = false;
                    responce.InvalidMaxMembers = true;
                    responce.InvalidMaxComands = true;
                    responce.InvalidMaxComandsMembers = true;
                }
            }
            if (userId > 0)
            {
                var currentCompetition = await db.Competitions.FirstOrDefaultAsync(u => u.Id == competition.Id);
                if(currentCompetition.UserId != userId)
                {
                    responce.Successful = false;
                    responce.NotOwner = true;
                }
            }
            return responce;
        }
    }
}
