using AdventOfCode2017.Eleven;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class DayElvenTests
    {
        [Theory]
        [InlineData("ne,ne,ne", 3)]
        [InlineData("ne,ne,sw,sw", 0)]
        [InlineData("ne,ne,s,s", 2)]
        [InlineData("se,sw,se,sw,sw", 3)]
        public void CalculateMinimumSteps(string moves, int expected)
        {
            var sut = new DayEleven();
            var result = sut.CalculateSteps(moves);

            Assert.Equal(expected, result.EndSteps);
        }

        [Fact]
        public void TestPartA()
        {
            var sut = new DayEleven();
            var result = sut.PartA();

            Assert.Equal("773", result);
        }

        [Fact]
        public void TestPartB()
        {
            var sut = new DayEleven();
            var result = sut.PartB();

            Assert.Equal("1560", result);
        }
    }
}