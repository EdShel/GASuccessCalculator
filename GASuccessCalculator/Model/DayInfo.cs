using System;

namespace GASuccessCalculator.Model
{
    public class DayInfo
    {
        public DateTime Date { set; get; }

        public double IAPRevenue { set; get; }

        public double AdsRevenue { set; get; }

        /// <summary>
        /// Daily active users, the number of unique users 
        /// that start at least one session in the app on any given day.
        /// </summary>
        public double DAU { set; get; }

        public double MAU { set; get; }

        public double LAU { set; get; }

        public int NewUsers { set; get; }

        /// <summary>
        /// How many users paid.
        /// </summary>
        public int PAU { set; get; }

        public int SocialNetPosts { set; get; }

        public double AvgSessionDur { set; get; }

        /// <summary>
        /// How many times each user started the game to play.
        /// If users are coming back five to ten times each day, 
        /// it’s safe to assume they enjoy the game. 
        /// If users only open an app one to two times per day, 
        /// it is unlikely to keep their attention for long.
        /// </summary>
        public double AvgSessionCount { set; get; }

        public override string ToString()
        {
            return $"{Date: yyyy-MM-dd} {IAPRevenue:$0.00} {AdsRevenue:$0.00} " +
                    $"{DAU} {MAU} {LAU} {NewUsers} {PAU} {SocialNetPosts} " +
                    $"{AvgSessionDur:0.00} {AvgSessionCount:0.00}";
        }

        /// <summary>
        /// Paying users.
        /// </summary>
        public double PU => DAU / PAU;

        /// <summary>
        /// DAU / MAU. How frequently users log in to the app.
        /// The most successful gaming apps have ratios closer 
        /// to 20 percent.
        /// </summary>
        public double Stickiness => DAU / MAU;

        /// <summary>
        /// Average revenue from one active user.
        /// </summary>
        // In presentation: public double ARPU => (IAPRevenue + AdsRevenue) / NewUsers;
        public double ARPU => (IAPRevenue + AdsRevenue) / DAU;
        
        /// <summary>
        /// Average Revenue Per Paying User (ARPPU) measures only the subset 
        /// of users who have completed a purchase in a game. 
        /// </summary>
        public double ARPPU => IAPRevenue / PAU;
    }
}
