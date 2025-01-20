namespace UnitConverter.UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            Run(new ConsoleWrapper());
        }

        public static void Run(IConsole console)
        {
            console.WriteLine("Bitte gib folgende Angaben ein:");
            console.Write("Entfernung [m|km|mi]: ");
            var distance = console.ReadLine();

            console.Write("Zeit [hh:mm:ss]: ");
            var timespan = console.ReadLine();

            console.WriteLine();

            var speed = new Speedometer(distance, timespan);

            //Ausgaben inkl. Rundungen auf zwei Nachkommastellen
            console.WriteLine($"Meter/Sekunde:\t\t {Math.Round(speed.ToMeterPerSeconds(), 2)}");
            console.WriteLine($"Kilometer/Stunde:\t {Math.Round(speed.ToKilometerPerHour(), 2)}");
            console.WriteLine($"Meilen/Stunde:\t\t {Math.Round(speed.ToMilesPerHour(), 2)}");
        }
    }
}
