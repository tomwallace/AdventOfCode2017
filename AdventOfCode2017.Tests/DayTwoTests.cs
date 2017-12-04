using AdventOfCode2017.Two;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class DayTwoTests
    {
        [Theory]
        [InlineData("5	1	9	5", 8)]
        [InlineData("7	5	3", 4)]
        [InlineData("2	4	6	8", 6)]
        public void testCalculateLineDifference(string line, long expected)
        {
            var sut = new DayTwo();
            var result = sut.CalculateLineDifference(line);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("5	9	2	8", 4)]
        [InlineData("9	4	7	3", 3)]
        [InlineData("3	8	6	5", 2)]
        public void testCalculateLineEvenDivision(string line, long expected)
        {
            var sut = new DayTwo();
            var result = sut.CalculateLineEvenDivision(line);

            Assert.Equal(expected, result);
        }


        [Fact]
        public void testCalculateChecksum_PartA()
        {
            var sut = new DayTwo();
            var result = sut.CalculateChecksumA();

            Assert.Equal(53460, result);
        }

        [Fact]
        public void testCalculateChecksum_PartB()
        {
            var sut = new DayTwo();
            var result = sut.CalculateChecksumB();

            Assert.Equal(282, result);
        }
    }
}