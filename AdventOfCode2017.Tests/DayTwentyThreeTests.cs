using AdventOfCode2017.TwentyThree;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class DayTwentyThreeTests
    {
        [Fact]
        public void TestPartA()
        {
            var sut = new DayTwentyThree();
            var result = sut.PartA();

            Assert.Equal("9409", result);
        }

        [Fact]
        public void TestPartB()
        {
            var sut = new DayTwentyThree();
            var result = sut.PartB();
            Assert.Equal("913", result);
        }
    }
}