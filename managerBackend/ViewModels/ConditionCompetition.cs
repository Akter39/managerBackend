namespace managerBackend.ViewModels
{
    public class ConditionCompetition
    {
        public bool Successful { get; set; } = true;
        public bool NotOwner { get; set; }
        public bool InvalidName { get; set; }
        public bool InvalidStartDate { get; set; }
        public bool InvalidEndDate { get; set; }
        public bool InvalidRangeDate { get; set; }
        public bool InvalidBid { get; set; }
        public bool InvalidPoolLength { get; set; }
        public bool InvalidPoolLanes { get; set; }
        public bool InvalidContributuon { get; set; }
        public bool InvalidMaxMembers { get; set; }
        public bool InvalidMaxComands { get; set; }
        public bool InvalidMaxComandsMembers { get; set; }

    }
}
