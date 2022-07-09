using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace managerBackend.Models
{
    public class Distance
    {
        [BindNever]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Competition> Competitions { get; set; } = new List<Competition>();
        public Distance(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
