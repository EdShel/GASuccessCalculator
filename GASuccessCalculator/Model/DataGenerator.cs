using System;
using System.Collections.Generic;

namespace GASuccessCalculator.Model
{

    public static class DataGenerator
    {
        public static IEnumerable<DayInfo> Generate(int variant)
        {
            Random r = new Random(variant);
            double avgDAU = (double)r.Next(1000, 5000);
            double avgStickiness = NextDouble(r, 0.1, 0.8);
            double avgPayingShare = NextDouble(r, 0.1, 0.3);
            double avgARPPU = NextDouble(r, 5.0, 9.0);
            double avgAvgAdRevenue = NextDouble(r, 0.5, 2.5);
            int lau = Convert.ToInt32(avgDAU / avgStickiness * 1.2 * NextDouble(r, 1.1, 4.5));
            double avgSocialNetPosts = NextDouble(r, 0.0, 2.5);
            double avgAvgSessionDur = NextDouble(r, 5.0, 40.0);
            double avgAvgSessionsCount = NextDouble(r, 1.0, 5.0);
            DateTime todaysDate = DateTime.Now;
            int curYear = todaysDate.Year;
            int curMonth = todaysDate.Month;
            DateTime currentDay = new DateTime(curYear, curMonth, 1);



#if ORIGINAL_CODE

            // OMG, don't even dare to run it in December

            int nextMonth = todaysDate.Month + 1; 
            DateTime maxDate = new DateTime(curYear, nextMonth, 1);
#else
            DateTime maxDate = currentDay.AddMonths(1);
#endif

            while (currentDay < maxDate)
            {
                int dau = Convert.ToInt32(avgDAU * NextDouble(r, 0.8, 1.2));
                double stickiness = avgStickiness * NextDouble(r, 0.95, 1.05);
                double arppu = avgARPPU * NextDouble(r, 0.8, 1.2);
                double avgAdRevenue = avgAvgAdRevenue * NextDouble(r, 0.8, 1.2);
                double payingShare = avgPayingShare * NextDouble(r, 0.8, 1.2);
                int pau = Convert.ToInt32((double)dau * payingShare);
                int mau = Convert.ToInt32(Convert.ToDouble(dau) / stickiness);
                int newUsers = Convert.ToInt32((double)dau * (1.0 - stickiness) * NextDouble(r, 0.2, 0.7));
                lau += newUsers;
                double inAppPurchRevenue = (double)pau * arppu;
                double adsRevenue = (double)(dau - pau) * avgAdRevenue;
                int socialNetPosts = Convert.ToInt32((double)dau * avgSocialNetPosts);
                double avgSessionDur = avgAvgSessionDur * NextDouble(r, 0.95, 1.05);
                double avgSessionCount = avgAvgSessionsCount * NextDouble(r, 0.9, 1.1);


                yield return new DayInfo
                {
                    Date = currentDay,
                    DAU = dau,
                    MAU = mau,
                    LAU = lau,
                    PAU = pau,
                    AvgSessionCount = avgSessionCount,
                    AvgSessionDur = avgSessionDur,
                    NewUsers = newUsers,
                    AdsRevenue = adsRevenue,
                    IAPRevenue = inAppPurchRevenue,
                    SocialNetPosts = socialNetPosts
                };
                currentDay = currentDay.AddDays(1.0);
            }
        }



        private static double NextDouble(Random r, double min, double max)
        {
            return Convert.ToDouble(r.Next(Convert.ToInt32(min * 100.0), Convert.ToInt32(max * 100.0))) / 100.0;
        }
    }
}
