namespace UnitConverter.Test
{
    [TestClass]
    public sealed class SpeedometerTest
    {

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
        }
    }
}
