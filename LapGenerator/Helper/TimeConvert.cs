using System.Globalization;

namespace LapGenerator.Helper
{
    public static class TimeConvert
    {
        public static string ToTimeString(this long secondValue)
        {
            TimeSpan ts = TimeSpan.FromMilliseconds(secondValue);
            return string.Format("{0:D2}:{1:D2}",
                    ts.Minutes,
                    ts.Seconds);
        }

        public static long ToLong(this string timeValue)
        {
            TimeSpan ts = TimeSpan.ParseExact(timeValue,@"mm\:ss",CultureInfo.InvariantCulture);
            return (long)ts.TotalMilliseconds;
        }
    }
}
