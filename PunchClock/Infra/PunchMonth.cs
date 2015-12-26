using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace PunchClock.Infra
{
    public class PunchMonth
    {
        public PunchMonth()
        {
            Days = new Dictionary<int, PunchDay>();
        }

        public int Month { get; set; }
        public int Year { get; set; }
        public IDictionary<int, PunchDay> Days { get; set; }

        public override string ToString()
        {
            return new DateTime(Year, Month, 0).ToString("MMMM yyyy");
        }
    }

    public class PunchDay
    {
        public PunchDay()
        {
            Entries = new List<PunchEntry>();
        }

        public int Day { get; set; }
        public IList<PunchEntry> Entries { get; set; }

        [JsonIgnore]
        public DateTime StartTime => Entries.Min(x => x.PunchIn);
        [JsonIgnore]
        public DateTime EndTime => Entries.Max(x => x.PunchIn);
        [JsonIgnore]
        public TimeSpan RecessTime => TotalTime - WorkTime;
        [JsonIgnore]
        public TimeSpan TotalTime => EndTime - StartTime;
        [JsonIgnore]
        public TimeSpan WorkTime => Entries.Aggregate(TimeSpan.Zero, (sumSoFar, nextEntry) => sumSoFar + nextEntry.Duration);

        public override string ToString()
        {
            return $"{Day} - {WorkTime.ToTimeString()}";
        }
    }

    public class PunchEntry
    {
        public DateTime PunchIn { get; set; }
        public DateTime PunchOut { get; set; }

        [JsonIgnore]
        public TimeSpan Duration => PunchOut - PunchIn;
    }
}