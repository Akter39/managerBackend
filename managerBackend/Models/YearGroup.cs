namespace managerBackend.Models
{
    public class YearGroup
    {
        public int Id { get; set; }
        public DateOnly StartYear { get; set; }
        public DateOnly? EndYear { get; set; }
        public bool Infinity { get; set; }
        List<Competition> Competitions { get; set; } = new();
        public YearGroup(int id, DateOnly startYear, DateOnly? endYear, bool infinity)
        {
            Id = id;
            StartYear = startYear;
            EndYear = endYear;
            Infinity = infinity;
            if (!this.VerificationYearGroup()) throw new ArgumentException("Argument didn't pass verification");
        }
    }

    public static class YearGroupExtension
    {
        public static bool VerificationYearGroup(this YearGroup group)
        {
            if (group.StartYear >= group.EndYear) return false;
            if (group.EndYear != null && group.Infinity == true) return false;
            return true;
        }
    }
}
