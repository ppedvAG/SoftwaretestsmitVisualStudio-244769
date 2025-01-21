using System.Text;

namespace UnitConverter.Test
{
    [TestClass]
    public sealed class SpeedometerTest
    {
        // Property vom Typ TestContext MUSS TestContext heißen
        // Wird vom MSTest Framework automatisch befüllt
        public TestContext TestContext { get; set; }

        [TestMethod]
        [DataRow("4500", "1:5:25")]
        [DataRow("4500", "01:05:25")]
        public void ParseDistance_ConvertsToSpeed(string distance, string time)
        {
            // Arrange
            // uut = unit under test
            var _uut = new Speedometer(distance, time);
            double expectedMps = 1.1464968152866242;
            double expectedKph = 4.127388535031847;
            double expectedMph = 2.5646404065903585;

            // Act
            var actualMps = _uut.ToMeterPerSeconds();
            var actualKph = _uut.ToKilometerPerHour();
            var actualMph = _uut.ToMilesPerHour();

            // Assert
            Assert.AreEqual(expectedMps, actualMps);
            Assert.AreEqual(expectedKph, actualKph);
            Assert.AreEqual(expectedMph, actualMph);

            // Beispiel Testergebnisse in Datei schreiben
            var sb = new StringBuilder();
            sb.AppendLine($"Expected Mps: {expectedMps} m/s \tActual Mps: {actualMps} m/s");
            sb.AppendLine($"Expected Kph: {expectedKph} km/h \tActual Kph: {actualKph} km/h");
            sb.AppendLine($"Expected Mph: {expectedMph} mph \tActual Mph: {actualMph} mph");
            WriteTestResults(sb);
        }

        private void WriteTestResults(StringBuilder sb)
        {
            var fileName = TestContext.TestName + ".txt";
            var path = Path.Combine(TestContext.TestResultsDirectory, fileName);
            File.WriteAllText(path, sb.ToString());
        }
    }
}
