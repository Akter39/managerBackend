using System.ComponentModel.DataAnnotations;

namespace managerBackend.Models
{
    public class Role
    {
        public int Id { get; set; }
        [MaxLength(32)]
        public string Name { get; set; }
        public List<User> Users { get; set; } = new List<User>();
    }
}
