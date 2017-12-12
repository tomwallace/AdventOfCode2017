using AdventOfCode2017.Twelve;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class DayTwelveTests
    {
        [Fact]
        public void TestCalculateProgramsDisconnected()
        {
            var filePath = @"Twelve\DayTwelveTestInput.txt";
            var sut = new DayTwelve();
            var result = sut.CalculateProgramsConnected(filePath);

            Assert.Equal(6, result);
        }

        [Fact]
        public void TestCalculateNumberProgramGroups()
        {
            var filePath = @"Twelve\DayTwelveTestInput.txt";
            var sut = new DayTwelve();
            var result = sut.CalculateNumberProgramGroups(filePath);

            Assert.Equal(2, result);
        }

        [Fact]
        public void TestPartA()
        {
            var sut = new DayTwelve();
            var result = sut.PartA();

            Assert.Equal("128", result);
        }

        [Fact]
        public void TestPartB()
        {
            var sut = new DayTwelve();
            var result = sut.PartB();

            Assert.Equal("209", result);
        }
    }
}