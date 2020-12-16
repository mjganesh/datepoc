using System;

namespace DatetimeAPI
{
    public class WeekDay
    {
        public string DayOfWeek { get; set; }
        public bool OptionParam { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public TimeSpan NextDayTime { get; set; }
        public TimeSpan SecondAfterDayTime { get; set; }
    }
}
