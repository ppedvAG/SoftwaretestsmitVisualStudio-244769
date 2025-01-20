namespace UnitConverter
{
    public enum DistanceUnit
    {
        m,
        km,
        mi
    }

    public class Speedometer
    {
        public const float MilesPerKilometer = 1.609344f;
        public const float KilometersPerMiles = 0.62137119f;

        private readonly string distance;
        private readonly string timespan;

        private UnitParser parser = new UnitParser();

        public Speedometer(string distance, string timespan)
        {
            this.distance = distance;
            this.timespan = timespan;
        }

        public double ToKilometerPerHour() 
            => ToMeterPerSeconds() * 3.6;

        public double ToMeterPerSeconds()
        {
            var (number, unit) = parser.ParseDistance(distance);
            double factor = AsMeters(unit);
            var time = parser.ParseTime(timespan);
            return number * factor / time.TotalSeconds;
        }

        private double AsMeters(DistanceUnit unit) => unit switch
        {
            DistanceUnit.km => 1000,
            DistanceUnit.mi => MilesPerKilometer * 1000,
            _ => (double)1,
        };

        public double ToMilesPerHour()
        {
            var (number, unit) = parser.ParseDistance(distance);
            double factor = AsMiles(unit);
            var time = parser.ParseTime(timespan);
            return number * factor / time.TotalHours;
        }

        private double AsMiles(DistanceUnit unit) => unit switch
        {
            DistanceUnit.km => KilometersPerMiles,
            DistanceUnit.m => KilometersPerMiles * 1e-3,
            _ => 1,
        };
    }
}
