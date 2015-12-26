using System;

namespace PunchClock.Infra
{
    public static class ExtensionMethods
    {
        public static string ToTimeString(this TimeSpan timeSpan)
        {
            return timeSpan.ToString(@"hh\:mm\:ss");
        }

        public static string ToTimeString(this DateTime dateTime)
        {
            return dateTime.ToString(@"HH\:mm\:ss");
        }
    }
}