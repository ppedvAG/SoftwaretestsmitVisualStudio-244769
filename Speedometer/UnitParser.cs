namespace UnitConverter
{
    public class UnitParser
    {
        public TimeSpan ParseTime(string time)
        {
            if (!string.IsNullOrWhiteSpace(time))
            {
                var parts = time.Split(':').Select(ParseInt).ToArray();
                if (parts.Length == 3 && parts.All(i => i.HasValue))
                {
                    return new TimeSpan(parts[0]!.Value, parts[1]!.Value, parts[2]!.Value);
                }
            }

            throw new ArgumentException("Invalid timespan");
        }

        public (int, DistanceUnit) ParseDistance(string distance)
        {
            var parts = distance?.Split(' ');
            if (parts?.Length > 0)
            {
                var number = ParseInt(parts[0]);
                if (number.HasValue && number.Value >= 0)
                {
                    if (parts.Length > 1)
                    {
                        var unit = Enum.Parse<DistanceUnit>(parts[1]);
                        return (number.Value, unit);
                    }
                    else
                    {
                        return (number.Value, DistanceUnit.m);
                    }
                }
            }

            throw new ArgumentException("Invalid distance");
        }

        private int? ParseInt(string number)
        {
            return int.TryParse(number, out var result) ? result : null;
        }

    }
}
