using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MockBank
{
    public class OpeningHours
    {
        public ITimeService TimeService { get; }

        public OpeningHours() : this(new TimeService())
        {
        }

        public OpeningHours(ITimeService timeService)
        {
            TimeService = timeService;
        }

        public bool IsWeekend()
        {
            return TimeService.Now.DayOfWeek == DayOfWeek.Saturday || TimeService.Now.DayOfWeek == DayOfWeek.Sunday;
        }

        // In der Praxis ist es unwahrscheinlich, dass DateTime als Parameter uebergeben wird
        public bool IsOpen(DateTime date)
        {
            if (date.DayOfWeek >= DayOfWeek.Monday && date.DayOfWeek <= DayOfWeek.Friday)
            {
                if (date.TimeOfDay >= new TimeSpan(9, 0, 0) && date.TimeOfDay <= new TimeSpan(16, 0, 0))
                {
                    return true;
                }
            }
            else if (date.DayOfWeek == DayOfWeek.Saturday)
            {
                if (date.TimeOfDay >= new TimeSpan(9, 0, 0) && date.TimeOfDay <= new TimeSpan(12, 30, 0))
                {
                    return true;
                }
            }

            return false;
        }

        // Wahrscheinlicher Fall, dass wir direkt auf DateTime.Now zugreifen
        public bool IsNowOpen()
        {
            if (DateTime.Now.DayOfWeek >= DayOfWeek.Monday && DateTime.Now.DayOfWeek <= DayOfWeek.Friday)
            {
                if (DateTime.Now.TimeOfDay >= new TimeSpan(9, 0, 0) && DateTime.Now.TimeOfDay <= new TimeSpan(16, 0, 0))
                {
                    return true;
                }
            }
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
            {
                if (DateTime.Now.TimeOfDay >= new TimeSpan(9, 0, 0) && DateTime.Now.TimeOfDay <= new TimeSpan(12, 30, 0))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
