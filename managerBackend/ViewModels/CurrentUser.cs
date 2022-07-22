using managerBackend.Models;

using System.Text.Json.Serialization;

namespace managerBackend.ViewModels
{
    public class CurrentUser
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Organization { get; set; }
        public string City { get; set; }
        public List<string> Roles { get; set; }
        public string Token { get; set; }
        [JsonIgnore]
        public string RefreshJwt { get; set; }
    }
}
