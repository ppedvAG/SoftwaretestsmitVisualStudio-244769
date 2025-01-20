namespace MockBank
{
    // Quasi ein Wrapper, welcher uns DateTime.Now weg abstrahiert
    public class TimeService : ITimeService
    {
        public DateTime Now => DateTime.Now;
    }
}
