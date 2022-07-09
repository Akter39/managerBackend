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

        [BindNever]
        public List<Distance> Distances { get; set; } = new List<Distance>();
        [BindNever]
        public int UserId { get; set; }
        [BindNever]
        public User User { get; set; }
    }
}
