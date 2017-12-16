using AdventOfCode2017.Fourteen;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class DayFourteenTests
    {
        [Theory]
        [InlineData("0", "0000")]
        [InlineData("1", "0001")]
        [InlineData("e", "1110")]
        [InlineData("f", "1111")]
        [InlineData("a0c2017", "1010000011000010000000010111")]
        public void TestConvertHexDigit(string input, string expected)
        {
            var sut = new DayFourteen();
            var result = sut.ConvertHexToBinaryString(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestCalculateNumberOfUsedSquares()
        {
            var baseInput = "flqrgnkx";
            var sut = new DayFourteen();
            var result = sut.CalculateNumberOfUsedSquares(baseInput);

            Assert.Equal(8108, result);
        }

        [Theory]
        [InlineData("flqrgnkx-0", "11010100")]
        [InlineData("flqrgnkx-1", "01010101")]
        [InlineData("flqrgnkx-2", "00001010")]
        [InlineData("flqrgnkx-3", "10101101")]
        [InlineData("flqrgnkx-4", "01101000")]
        public void TestCreateFragmenterRow(string input, string expectedStart)
        {
            var sut = new DayFourteen();
            var result = sut.CreateFragmenterRow(input);
            var start = result.Substring(0, 8);

            Assert.Equal(expectedStart, start);
        }

        // Takes 5 min to run - only uncomment if necessary
        /*
        [Fact]
        public void TestDiskCalculateNumberOfRegions()
        {
            var baseInput = "flqrgnkx";
            var sut = new DayFourteen();
            var result = sut.CalculateNumberOfRegions(baseInput);

            Assert.Equal(1242, result);
        }
        */

        [Fact]
        public void TestPartA()
        {
            var sut = new DayFourteen();
            var result = sut.PartA();

            Assert.Equal("8222", result);
        }

        // Takes 5 min to run - only uncomment if necessary
        /*
        [Fact]
        public void TestPartB()
        {
            var sut = new DayFourteen();
            var result = sut.PartB();

            Assert.Equal("1086", result);
        }
        */
    }
}