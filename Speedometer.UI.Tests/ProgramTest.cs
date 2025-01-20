using FakeItEasy;
using Moq;
using NSubstitute;

namespace UnitConverter.UI.Tests
{
    [TestClass]
    public sealed class ProgramTest
    {
        [TestMethod]
        public void Run_ValidInputUsingMoq_ShouldCalculateAndDisplaySpeed()
        {
            // Arrange
            var consoleMock = new Mock<IConsole>();
            consoleMock.SetupSequence(c => c.ReadLine())
                .Returns("10 km")
                .Returns("00:30:00");

            // Act
            Program.Run(consoleMock.Object);

            // Assert
            consoleMock.Verify(c => c.WriteLine("Bitte gib folgende Angaben ein:"), Moq.Times.Once());
            consoleMock.Verify(c => c.Write("Entfernung [m|km|mi]: "), Moq.Times.Once());
            consoleMock.Verify(c => c.Write("Zeit [hh:mm:ss]: "), Moq.Times.Once());
            consoleMock.Verify(c => c.WriteLine($"Meter/Sekunde:\t\t {Math.Round(5.56, 2)}"), Moq.Times.Once());
            consoleMock.Verify(c => c.WriteLine($"Kilometer/Stunde:\t {Math.Round(20.0, 2)}"), Moq.Times.Once());
            consoleMock.Verify(c => c.WriteLine($"Meilen/Stunde:\t\t {Math.Round(12.43, 2)}"), Moq.Times.Once());
        }

        [TestMethod]
        public void Run_ValidInputUsingNSubstitute_ShouldCalculateAndDisplaySpeed()
        {
            // Arrange
            var consoleMock = Substitute.For<IConsole>();
            consoleMock.ReadLine().Returns("10 km", "00:30:00");

            // Act
            Program.Run(consoleMock);

            // Assert
            consoleMock.Received(1).WriteLine("Bitte gib folgende Angaben ein:");
            consoleMock.Received(1).Write("Entfernung [m|km|mi]: ");
            consoleMock.Received(1).Write("Zeit [hh:mm:ss]: ");
            consoleMock.Received(1).WriteLine($"Meter/Sekunde:\t\t {Math.Round(5.56, 2)}");
            consoleMock.Received(1).WriteLine($"Kilometer/Stunde:\t {Math.Round(20.0, 2)}");
            consoleMock.Received(1).WriteLine($"Meilen/Stunde:\t\t {Math.Round(12.43, 2)}");
        }

        [TestMethod]
        public void Run_ValidInputUsingFakeItEasy_ShouldCalculateAndDisplaySpeed()
        {
            // Arrange
            var consoleMock = A.Fake<IConsole>();
            A.CallTo(() => consoleMock.ReadLine()).Returns("10 km").Once()
                .Then.Returns("00:30:00");

            // Act
            Program.Run(consoleMock);

            // Assert
            A.CallTo(() => consoleMock.WriteLine("Bitte gib folgende Angaben ein:")).MustHaveHappenedOnceExactly();
            A.CallTo(() => consoleMock.Write("Entfernung [m|km|mi]: ")).MustHaveHappenedOnceExactly();
            A.CallTo(() => consoleMock.Write("Zeit [hh:mm:ss]: ")).MustHaveHappenedOnceExactly();
            A.CallTo(() => consoleMock.WriteLine($"Meter/Sekunde:\t\t {Math.Round(5.56, 2)}")).MustHaveHappenedOnceExactly();
            A.CallTo(() => consoleMock.WriteLine($"Kilometer/Stunde:\t {Math.Round(20.0, 2)}")).MustHaveHappenedOnceExactly();
            A.CallTo(() => consoleMock.WriteLine($"Meilen/Stunde:\t\t {Math.Round(12.43, 2)}")).MustHaveHappenedOnceExactly();
        }

    }
}
