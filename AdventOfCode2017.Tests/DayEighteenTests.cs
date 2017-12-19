using AdventOfCode2017.Eighteen;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class DayEighteenTests
    {
        [Fact]
        public void TestRunThroughInstructions()
        {
            string filePath = @"Eighteen\DayEighteenTestInput.txt";
            var sut = new DayEighteen();
            var result = sut.RunThroughInstructions(filePath);

            Assert.Equal("4", result);
        }

        [Fact]
        public void TestPartA()
        {
            var sut = new DayEighteen();
            var result = sut.PartA();

            Assert.Equal("7071", result);
        }

        [Fact]
        public void TestPartB()
        {
            var sut = new DayEighteen();
            var result = sut.PartB();

            Assert.Equal("8001", result);
        }
    }
}