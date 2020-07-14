using System;

namespace WeatherApp
{
    static class UnixConverter
    {
        static public DateTime ConvertFromUnixTimestamp(double timestamp, string timezone)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            if (timezone == "Europe/Moscow")
                return origin.AddSeconds(10800 + timestamp);
            else if (timezone == "Europe/Rome")
                // If not summer, then +3600.
                return origin.AddSeconds(7200 + timestamp);
            else if (timezone == "Africa/Cairo")
                return origin.AddSeconds(7200 + timestamp);
            else if (timezone == "Pacific/Auckland")
                return origin.AddSeconds(43200 + timestamp);
            else if (timezone == "America/Los_Angeles")
                return origin.AddSeconds(timestamp - 25200);
            else if (timezone == "America/Sao_Paulo")
                return origin.AddSeconds(timestamp - 10800);
            else
                return origin.AddSeconds(timestamp);
        }
    }
}
