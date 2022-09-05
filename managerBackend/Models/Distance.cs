using managerBackend.Constants;

using Microsoft.AspNetCore.Mvc.ModelBinding;

using System.Text.Json.Serialization;

namespace managerBackend.Models
{
    public class Distance
    {
        [BindNever]
        [JsonIgnore]
        public int Id { get; set; }
        public string Dist { get; set; }
        public string Style { get; set; }
        public string Gender { get; set; }
        public List<Competition> Competitions { get; set; } = new List<Competition>();
        public Distance(int id, string dist, string style, string gender)
        {
            Id = id;
            Dist = dist;
            Style = style;
            Gender = gender;
            if (!this.VerificationDistance()) throw new ArgumentException("Argument didn't pass verification");
        }
    }
    
    public static class DistanceExtension
    {
        public static bool VerificationDistance (this Distance distance)
        {
            DistanceStyleConstants distConst = new();
            foreach (var item in distConst)
            {
                string[] s = item.Split('.');
                if (
                    distance.Dist == s[0]
                    && 
                    distance.Style == s[1]
                    && (distance.Gender == GenderConstants.femail || distance.Gender == GenderConstants.mail))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
