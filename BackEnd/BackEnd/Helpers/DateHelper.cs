using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Helpers
{
    public class DateHelper
    {
        public static int DayDiff(DateTime d1, DateTime d2)
        {
            return (d1 - d2).Days;
        }
        public static long ToUnixEpochDate(DateTime date)
        {
            long res = (long)Math.Round((date.ToUniversalTime() -
                       new DateTimeOffset(1970, 1, 1, 0, 0, 0, 0, TimeSpan.Zero))
                      .TotalSeconds);
            return res;
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToUniversalTime();
            return dtDateTime;
        }

        public static bool DTIsNull(DateTime? d)
        {
            DateTime dnull = new DateTime(1, 1, 1, 0, 0, 0);
            return DateTime.Equals(dnull, d);
        }

        public static DateTime?  StringToDateTime(string date, string format=null)
        {
            DateTime? res = null;
            if (!StringHelper.IsNull(date))
            {
                if (format == null) { format = "dd/MM/yyyy"; }
                res = DateTime.ParseExact(date, format, null);
            }
            return res;
        }
    }
}
