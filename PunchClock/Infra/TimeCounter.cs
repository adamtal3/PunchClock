using System;

namespace PunchClock.Infra
{
    public class TimeCounter
    {
        private PunchEntry _currentEntry;
        private PunchMonth _currentMonth;
        private JsonFile<PunchMonth> _currentFile;

        private JsonFile<PunchMonth> GetFile()
        {
            var filename = DateTime.Now.ToString("yyyy-MM");
            return new JsonFile<PunchMonth>(filename);
        }

        public DateTime PunchIn()
        {
            _currentFile = GetFile();
            if (_currentFile.Exists())
                _currentMonth = _currentFile.Load();
            else
                _currentMonth = new PunchMonth { Year = DateTime.Now.Year, Month = DateTime.Now.Month };
            var today = DateTime.Now.Day;
            PunchDay day;
            if (_currentMonth.Days.ContainsKey(today))
                day = _currentMonth.Days[today];
            else
            {
                day = new PunchDay { Day = today };
                _currentMonth.Days[today] = day;
            }

            _currentEntry = new PunchEntry { PunchIn = DateTime.Now };
            day.Entries.Add(_currentEntry);
            _currentFile.Save(_currentMonth);
            return _currentEntry.PunchIn;
        }

        public TimeSpan PunchOut()
        {
            if (_currentEntry != null)
            {
                _currentEntry.PunchOut = DateTime.Now;
                _currentFile.Save(_currentMonth);
                return _currentEntry.Duration;
            }

            _currentFile = null;
            _currentMonth = null;
            _currentEntry = null;
            return new TimeSpan();
        }
    }
}