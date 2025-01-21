using Microsoft.QualityTools.Testing.Fakes;
using Moq;

namespace MockBank.Tests
{
    public class OpeningHoursTest
    {
        private readonly OpeningHours _openingHours = new OpeningHours();

        // Mit AI generiert
        [Theory]
        [InlineData("2025-01-20 09:00:00", true)]  // Montag, 9:00 Uhr (Öffnungszeit)
        [InlineData("2025-01-20 08:59:59", false)] // Montag, 8:59:59 Uhr (kurz vor Öffnung)
        [InlineData("2025-01-20 16:00:00", true)]  // Montag, 16:00 Uhr (Schließzeit)
        [InlineData("2025-01-20 16:00:01", false)] // Montag, 16:00:01 Uhr (kurz nach Schließung)
        [InlineData("2025-01-24 12:00:00", true)]  // Freitag, 12:00 Uhr (mitten am Tag)
        [InlineData("2025-01-25 09:00:00", true)]  // Samstag, 9:00 Uhr (Öffnungszeit)
        [InlineData("2025-01-25 12:30:00", true)]  // Samstag, 12:30 Uhr (Schließzeit)
        [InlineData("2025-01-25 12:30:01", false)] // Samstag, 12:30:01 Uhr (kurz nach Schließung)
        [InlineData("2025-01-26 10:00:00", false)] // Sonntag, 10:00 Uhr (geschlossen)
        [InlineData("2025-01-20 00:00:00", false)] // Montag, Mitternacht (geschlossen)
        [InlineData("2025-01-20 23:59:59", false)] // Montag, kurz vor Mitternacht (geschlossen)
        public void IsOpen_ReturnsCorrectResult(string dateTimeString, bool expected)
        {
            // Arrange
            DateTime dateTime = DateTime.Parse(dateTimeString);

            // Act
            bool result = _openingHours.IsOpen(dateTime);

            // Assert
            Assert.Equal(expected, result);
        }

        //[Fact]
        //public void IsNowOpen_ReturnsCorrectResult()
        //{
        //    // Arrange

        //    // Act
        //    bool result = _openingHours.IsNowOpen();

        //    // Assert
        //    Assert.Equal(true, result);
        //}


        [Theory]
        [InlineData(2025, 1, 20, 9, 0, 0, true)]   // Montag, 9:00 Uhr (Öffnungszeit)
        [InlineData(2025, 1, 20, 8, 59, 59, false)]// Montag, 8:59:59 Uhr (kurz vor Öffnung)
        [InlineData(2025, 1, 20, 16, 0, 0, true)]  // Montag, 16:00 Uhr (Schließzeit)
        [InlineData(2025, 1, 20, 16, 0, 1, false)] // Montag, 16:00:01 Uhr (kurz nach Schließung)
        [InlineData(2025, 1, 24, 12, 0, 0, true)]  // Freitag, 12:00 Uhr (mitten am Tag)
        [InlineData(2025, 1, 25, 9, 0, 0, true)]   // Samstag, 9:00 Uhr (Öffnungszeit)
        [InlineData(2025, 1, 25, 12, 30, 0, true)] // Samstag, 12:30 Uhr (Schließzeit)
        [InlineData(2025, 1, 25, 12, 30, 1, false)]// Samstag, 12:30:01 Uhr (kurz nach Schließung)
        [InlineData(2025, 1, 26, 10, 0, 0, false)] // Sonntag, 10:00 Uhr (geschlossen)
        [InlineData(2025, 1, 20, 0, 0, 0, false)]  // Montag, Mitternacht (geschlossen)
        [InlineData(2025, 1, 20, 23, 59, 59, false)]// Montag, kurz vor Mitternacht (geschlossen)
        public void IsNowOpen_UsingFakes_ReturnsCorrectResult(int year, int month, int day, int hour, int minute, int second, bool expected)
        {
            // Wir befinden uns hier im Shim Context wo wir Shims verwenden koennen, welche wir vorher in den Framework Referenzen "gefaked" haben
            using (ShimsContext.Create())
            {
                // Arrange
                var fakeDateTime = new DateTime(year, month, day, hour, minute, second);
                System.Fakes.ShimDateTime.NowGet = () => fakeDateTime;

                // Act
                bool result = _openingHours.IsNowOpen();

                // Assert
                Assert.Equal(expected, result);
            }
        }

        [Fact]
        public void IsWeekend_Moq_ReturnsTrueOnSunday()
        {
            // Arrange
            var mock = new Mock<ITimeService>();
            mock.Setup(m => m.Now).Returns(new DateTime(25, 1, 19));
            var uut = new OpeningHours(mock.Object);

            // Act
            var result = uut.IsWeekend();

            // Assert
            Assert.True(result);
            mock.Verify(m => m.Now, Times.AtLeast(1));

        }
    }
}