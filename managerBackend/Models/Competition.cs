using Microsoft.AspNetCore.Mvc.ModelBinding;

using System.ComponentModel.DataAnnotations;

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
        public DateTime BidDate { get; set; }
        public int Contribution { get; set; }
        public bool Individual { get; set; }
        public bool InvitOnly { get; set; }
        public int MaxMembers { get; set; }
        public int MaxComands { get; set; }
        public int MaxComandMembers { get; set; }
        public int CurrentMembers { get; set; }
        public int CurrentComands { get; set; }
        public List<Distance> Distances { get; set; } = new ();
        [BindNever]
        public int UserId { get; set; }
        [BindNever]
        public User User { get; set; }
    }
}
