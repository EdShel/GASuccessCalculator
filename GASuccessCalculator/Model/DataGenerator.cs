using System;
using System.Collections.Generic;

namespace GASuccessCalculator.Model
{

    public static class DataGenerator
    {
        public static IEnumerable<DayInfo> Generate(int variant)
        {
            Random r = new Random(variant);
            double num1 = (double)r.Next(1000, 5000);
            double num2 = NextDouble(r, 0.1, 0.8);
            double num3 = NextDouble(r, 0.1, 0.3);
            double num4 = NextDouble(r, 5.0, 9.0);
            double num5 = NextDouble(r, 0.5, 2.5);
            int lau = Convert.ToInt32(num1 / num2 * 1.2 * NextDouble(r, 1.1, 4.5));
            double num6 = NextDouble(r, 0.0, 2.5);
            double num7 = NextDouble(r, 5.0, 40.0);
            double num8 = NextDouble(r, 1.0, 5.0);
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
                int dau = Convert.ToInt32(num1 * NextDouble(r, 0.8, 1.2));
                double num9 = num2 * NextDouble(r, 0.95, 1.05);
                double num10 = num4 * NextDouble(r, 0.8, 1.2);
                double num11 = num5 * NextDouble(r, 0.8, 1.2);
                double num12 = num3 * NextDouble(r, 0.8, 1.2);
                int pau = Convert.ToInt32((double)dau * num12);
                int mau = Convert.ToInt32(Convert.ToDouble(dau) / num9);
                int newUsers = Convert.ToInt32((double)dau * (1.0 - num9) * NextDouble(r, 0.2, 0.7));
                lau += newUsers;
                double revenueShop = (double)pau * num10;
                double revenusAds = (double)(dau - pau) * num11;
                int socialNetPosts = Convert.ToInt32((double)dau * num6);
                double avgSessionDur = num7 * NextDouble(r, 0.95, 1.05);
                double avgSessionCount = num8 * NextDouble(r, 0.9, 1.1);


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
                    RevenueAds = revenusAds,
                    RevenueShop = revenueShop,
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
