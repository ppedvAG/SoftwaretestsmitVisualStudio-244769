using Xunit.Abstractions;

namespace Calculator.xTest
{
    public class CalcTests : IDisposable
    {
        #region Setup & Teardown

        public CalcTests(ITestOutputHelper output)
        {
            // Im Konstruktor koennen wir fuer jeden einzelnen Test Dinge vorbereiten

            // Bei MSTest waere es eine eigene Methode mit dem Attribut [TestInitialize]
        }

        // IDisposable ist ein besonderes Interface, dass eine Klasse als disposable markiert.
        // D.h. alles in dieser Methode wird beim dekonstruieren der Klasse ausgefuehrt
        // Diese Methode wird beim Ende des Tests von xUnit automatisch aufgerufen.
        public void Dispose()
        {
            // Hier wureden wir z. B. DB-Verbindungen schließen oder andere Ressourcen freigeben

            // Bei MSTest waere es eine eigene Methode mit dem Attribut [TestCleanup]
        }

        #endregion

        #region Add Tests

        [Fact]
        [Trait("Category", "Unit")]
        public void Add_1and2_Returns3()
        {
            // Arrange
            int expected = 3;
            var calc = new Calc();

            // Act
            var actual = calc.Add(1, 2);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Add_MaxAnd1_ThrowsOverflowException()
        {
            // Arrange
            var calc = new Calc();

            // Act
            Action act = () => calc.Add(int.MaxValue, 1);

            // Assert
            Assert.Throws<OverflowException>(act);
            //Assert.Throws<OverflowException>(() => calc.Add(int.MaxValue, 1));
        }

        [Theory]
        [InlineData(3, 4, 7)]
        [InlineData(1, -2, -1)]
        public void Add_PositiveSamples_ReturnsExpected(int a, int b, int expected)
        {
            // Arrange
            var calc = new Calc();

            // Act
            var actual = calc.Add(a, b);

            Assert.Equal(expected, actual);
        }


        #endregion
    }
}