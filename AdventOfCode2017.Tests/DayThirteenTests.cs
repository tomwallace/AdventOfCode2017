using AdventOfCode2017.Thirteen;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class DayThirteenTests
    {
        [Fact]
        public void TestCalculateTripSeverity()
        {
            var filePath = @"Thirteen\DayThirteenTestInput.txt";
            var sut = new DayThirteen();
            var result = sut.CalculateTripSeverity(filePath);

            Assert.Equal(24, result);
        }

        [Fact]
        public void TestCalculateMinDelayForSafePassage()
        {
            var filePath = @"Thirteen\DayThirteenTestInput.txt";
            var sut = new DayThirteen();
            var result = sut.CalculateMinDelayForSafePassage(filePath);

            Assert.Equal(10, result);
        }

        [Fact]
        public void TestPartA()
        {
            var sut = new DayThirteen();
            var result = sut.PartA();

            Assert.Equal("1844", result);
        }

        [Fact]
        public void TestPartB()
        {
            var sut = new DayThirteen();
            var result = sut.PartB();

            Assert.Equal("3897604", result);
        }
    }
}