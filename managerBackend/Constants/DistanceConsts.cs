using managerBackend.Helpers;

namespace managerBackend.Constants
{
    public class DistanceStyleConstants
    {
        List<string> distanceStyleConst = typeof(DistanceStyleConstants).GetPublicContants<string>();

        public const string FL50 = "50.Fl";
        public const string BK50 = "50.BK";
        public const string BR50 = "50.BR";
        public const string FR50 = "50.FR";

        public const string FL100 = "100.Fl";
        public const string BK100 = "100.BK";
        public const string BR100 = "100.BR";
        public const string FR100 = "100.FR";
        public const string IM100 = "100.IM";

        public const string FL200 = "200.Fl";
        public const string BK200 = "200.BK";
        public const string BR200 = "200.BR";
        public const string FR200 = "200.FR";
        public const string IM200 = "200.IM";

        public const string FR400 = "400.FR";
        public const string IM400 = "400.IM";

        public const string FR800 = "800.FR";
        public const string FR1500 = "1500.FR";

        public const string RLFR100 = "4x100.RLFR";
        public const string RLIM100 = "4x100.RLIM";
        public const string RLFR200 = "4x200.RLFR";

        public IEnumerator<string> GetEnumerator() => distanceStyleConst.GetEnumerator();
    }

    public class DistanceConstants
    {
        List<string> distancesConst = typeof(DistanceConstants).GetPublicContants<string>();

        public const string _50 = "50";
        public const string _100 = "100";
        public const string _200 = "200";
        public const string _400 = "400";
        public const string _800 = "800";
        public const string _1500 = "1500";
        public const string _4x100 = "4x100";
        public const string _4x200 = "4x200";

        public IEnumerator<string> GetEnumerator() => distancesConst.GetEnumerator();
    }

    public class StyleConstants
    {
        List<string> styleConst = typeof(StyleConstants).GetPublicContants<string>();

        public const string FL = "FL";
        public const string BK = "BK";
        public const string BR = "BR";
        public const string FR = "FR";
        public const string IM = "IM";
        public const string RLFR = "RLFR";
        public const string RLIM = "RLIM";

        public IEnumerator<string> GetEnumerator() => styleConst.GetEnumerator();
    }

    public class GenderConstants
    {
        List<string> genderConst = typeof(GenderConstants).GetPublicContants<string>();

        public const string mail = "mail";
        public const string femail = "femail";

        public IEnumerator<string> GetEnumerator() => genderConst.GetEnumerator();
    }
}
