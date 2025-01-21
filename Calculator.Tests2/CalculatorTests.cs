namespace Calculator.Tests2
{
    public class CalculatorTests
    {

        #region Multiply Tests

        [Theory]
        [Trait("Category", "Code Coverage")]
        [InlineData(1, 1, 1)] // Wir haben mit dieser Zeile eine Code Coverage von 100%
        [InlineData(2, 2, 4)] // Hiermit sichern wir Mutationen ab, dass z. B. * nicht durch / ersetzt werden kann
        public void Multiply_1and1_Returns1(int a, int b, int expected)
        {
            // Arrange 
            var calc = new Calc();

            // Act
            var result = calc.Multiply(a, b);

            // Assert
            Assert.Equal(expected, result);
        }

        #endregion
    }
}