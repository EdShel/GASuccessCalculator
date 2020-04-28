using System;

namespace GASuccessCalculator.Model
{
    public class DayInfo
    {
        public DateTime Date { set; get; }
        public double RevenueShop { set; get; }
        public double RevenueAds { set; get; }
        public double DAU { set; get; }
        public double MAU { set; get; }
        public double LAU { set; get; }
        public int NewUsers { set; get; }
        public int PAU { set; get; }
        public int SocialNetPosts { set; get; }
        public double AvgSessionDur { set; get; }
        public double AvgSessionCount { set; get; }

        public override string ToString()
        {
            return $"{Date: yyyy-MM-dd} {RevenueShop:$0.00} {RevenueAds:$0.00} " +
                    $"{DAU} {MAU} {LAU} {NewUsers} {PAU} {SocialNetPosts} " +
                    $"{AvgSessionDur:0.00} {AvgSessionCount:0.00}";
        }
    }
}
