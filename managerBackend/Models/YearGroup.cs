﻿using managerBackend.Constants;

using Microsoft.AspNetCore.Mvc.ModelBinding;

using System.Text.Json.Serialization;

namespace managerBackend.Models
{
    public class YearGroup
    {
        [BindNever]
        [JsonIgnore]
        public int Id { get; set; }
        public int StartYear { get; set; }
        public int? EndYear { get; set; }
        public bool Infinity { get; set; }
        public string Gender { get; set; }
        public List<Competition> Competitions { get; set; } = new List<Competition>();
        public YearGroup(int id, int startYear, int? endYear, bool infinity, string gender)
        {
            Id = id;
            StartYear = startYear;
            EndYear = endYear;
            Infinity = infinity;
            Gender = gender;
            if (!this.VerificationYearGroup()) throw new ArgumentException("Argument didn't pass verification");
        }
    }

    public static class YearGroupExtension
    {
        public static bool VerificationYearGroup(this YearGroup group)
        {
            if (group.StartYear >= group.EndYear) return false;
            if (group.EndYear != null && group.Infinity == true) return false;
            if (group.Gender != GenderConstants.femail && group.Gender != GenderConstants.mail) return false;
            return true;
        }
    }
}
