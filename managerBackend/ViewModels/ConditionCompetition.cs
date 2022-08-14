namespace managerBackend.ViewModels
{
    public class ConditionCompetition
    {
        public bool Successful { get; set; } = true;
        public bool NotOwner { get; set; } = false;
        public bool InvalidName { get; set; } = false;
        public bool InvalidStartDate { get; set; } = false;
        public bool InvalidEndDate { get; set; } = false;
        public bool InvalidRangeDate { get; set; } = false;
        public bool InvalidBid { get; set; } = false;
        public bool InvalidPoolLength { get; set; } = false;
        public bool InvalidPoolLanes { get; set; } = false;
        public bool InvalidContributuon { get; set; } = false;
        public bool InvalidMaxMembers { get; set; } = false;
        public bool InvalidMaxComands { get; set; } = false;
        public bool InvalidMaxComandsMembers { get; set; } = false;
        public bool InvalidDistances { get; set; } = false;
        public bool InvalidYearGroup { get; set; } = false;
        public bool NotPay { get; set; } = false;

    }
}
