using AdventOfCode2017.TwentyFour;
using System.Linq;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class DayTwentyFourTests
    {
        [Fact]
        public void TestFindStrengthOfStrongestBridge()
        {
            string filePath = @"TwentyFour\DayTwentyFourTestInput.txt";
            var sut = new DayTwentyFour();
            var states = sut.FindStrengthOfStrongestBridge(filePath);
            int result = states.Select(s => s.TotalStrength).Max();

            Assert.Equal(31, result);
        }

        [Fact]
        public void TestPartA()
        {
            var sut = new DayTwentyFour();
            var result = sut.PartA();

            Assert.Equal("2006", result);
        }

        [Fact]
        public void TestPartB()
        {
            var sut = new DayTwentyFour();
            var result = sut.PartB();

            // 43 is incorrect
            Assert.Equal("1994", result);
        }
    }
}