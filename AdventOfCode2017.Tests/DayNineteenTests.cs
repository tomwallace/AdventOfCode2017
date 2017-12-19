using AdventOfCode2017.Nineteen;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class DayNineteenTests
    {
        [Fact]
        public void TestNavigateMap_Letters()
        {
            string filePath = @"Nineteen\DayNineteenTestInput.txt";
            var sut = new DayNineteen();
            var result = sut.NavigateMap(filePath);

            Assert.Equal("ABCDEF", result.Letters);
        }

        [Fact]
        public void TestNavigateMap_Numbers()
        {
            string filePath = @"Nineteen\DayNineteenTestInput.txt";
            var sut = new DayNineteen();
            var result = sut.NavigateMap(filePath);

            Assert.Equal(38, result.NumberOfSteps);
        }

        [Fact]
        public void TestPartA()
        {
            var sut = new DayNineteen();
            var result = sut.PartA();

            Assert.Equal("AYRPVMEGQ", result);
        }

        [Fact]
        public void TestPartB()
        {
            var sut = new DayNineteen();
            var result = sut.PartB();

            Assert.Equal("16408", result);
        }
    }
}