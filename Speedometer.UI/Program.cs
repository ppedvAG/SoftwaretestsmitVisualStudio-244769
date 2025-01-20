namespace Speedometer.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        public static void Run()
        {
            Console.WriteLine("Bitte gib folgende Angaben ein:");
            Console.Write("Entfernung [m|km|mi]: ");
            var distance = Console.ReadLine();

            Console.Write("Zeit [hh:mm:ss]: ");
            var timespan = Console.ReadLine();

            Console.WriteLine();

            var speed = new UnitConverter.Speedometer(distance, timespan);

            //Ausgaben inkl. Rundungen auf zwei Nachkommastellen
            Console.WriteLine($"Meter/Sekunde:\t\t {Math.Round(speed.ToMeterPerSeconds(), 2)}");
            Console.WriteLine($"Kilometer/Stunde:\t {Math.Round(speed.ToKilometerPerHour(), 2)}");
            Console.WriteLine($"Meilen/Stunde:\t\t {Math.Round(speed.ToMilesPerHour(), 2)}");
        }
    }
}
