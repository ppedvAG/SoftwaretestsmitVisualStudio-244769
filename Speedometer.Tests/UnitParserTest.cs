namespace UnitConverter.Test
{
    [TestClass]
    public sealed class UnitParserTest
    {
        // uut = unit under test
        private static readonly UnitParser _uut = new();

        [TestMethod]
        [DataRow("1", 1, "m")]
        [DataRow("1 m", 1, "m")]
        [DataRow("1 km", 1, "km")]
        [DataRow("1 mi", 1, "mi")]
        public void ParseDistance_ValidInput_ReturnsDistance(string input, double expectedNumber, string expectedUnit)
        {

            var (number, unit) = _uut.ParseDistance(input);

            Assert.AreEqual(expectedNumber, number);
            Assert.AreEqual(expectedUnit, unit.ToString());
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("w")]
        [DataRow("123 whatever")]
        [DataRow("1.5 m")]
        [DataRow("1,5 m")]
        [DataRow("-1 m")]
        public void ParseDistance_InvalidInput_ThrowsArgumentException(string input)
        {
            Assert.ThrowsException<ArgumentException>(() => _uut.ParseDistance(input));
        }
    }
}
