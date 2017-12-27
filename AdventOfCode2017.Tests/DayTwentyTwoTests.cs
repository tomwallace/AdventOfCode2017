using AdventOfCode2017.TwentyTwo;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class DayTwentyTwoTests
    {
        [Fact]
        public void TestCountInfectionActionsInCluster()
        {
            string filePath = @"TwentyTwo\DayTwentyTwoTestInput.txt";
            var sut = new DayTwentyTwo();
            var result = sut.CountInfectionActionsInCluster(filePath, 1, false, 10000);
            Assert.Equal(5587, result);
        }

        [Fact]
        public void TestCountInfectionActionsInCluster_Resistant_Low()
        {
            string filePath = @"TwentyTwo\DayTwentyTwoTestInput.txt";
            var sut = new DayTwentyTwo();
            var result = sut.CountInfectionActionsInCluster(filePath, 1, true, 100);
            Assert.Equal(26, result);
        }

        [Fact]
        public void TestCountInfectionActionsInCluster_Resistant_High()
        {
            string filePath = @"TwentyTwo\DayTwentyTwoTestInput.txt";
            var sut = new DayTwentyTwo();
            var result = sut.CountInfectionActionsInCluster(filePath, 1, true, 10000000);
            Assert.Equal(2511944, result);
        }

        [Fact]
        public void TestPartA()
        {
            var sut = new DayTwentyTwo();
            var result = sut.PartA();

            Assert.Equal("5176", result);
        }

        [Fact]
        public void TestPartB()
        {
            var sut = new DayTwentyTwo();
            var result = sut.PartB();

            Assert.Equal("2512017", result);
        }
    }
}