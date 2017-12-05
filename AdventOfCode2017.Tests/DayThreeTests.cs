using AdventOfCode2017.Three;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class DayThreeTests
    {
        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(12, 4, 4)]
        [InlineData(13, 4, 4)]
        [InlineData(22, 6, 5)]
        [InlineData(26, 6, 5)]
        public void testSpiralGrid_SetDimensions(long steps, long expectedWidth, long expectedHeight)
        {
            var spiralGrid = new SpiralGrid(steps);
            Assert.Equal(expectedWidth, spiralGrid.Width);
            Assert.Equal(expectedHeight, spiralGrid.Height);
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(12, 3)]
        [InlineData(13, 4)]
        [InlineData(23, 2)]
        [InlineData(1024, 31)]
        public void testSpiralGrid_ManhattanDistance(long steps, long expectedDist)
        {
            var spiralGrid = new SpiralGrid(steps);
            Assert.Equal(expectedDist, spiralGrid.ManhattanDistance());
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(6, 10)]
        [InlineData(143, 147)]
        public void testCalculateNextCellValue(int puzzleInput, int expected)
        {
            var sut = new DayThree();
            var result = sut.CalculateNextCellValue(puzzleInput);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void testPartA()
        {
            var sut = new DayThree();
            var result = sut.PartA();

            Assert.Equal("475", result);
        }

        [Fact]
        public void testPartB()
        {
            var sut = new DayThree();
            var result = sut.PartB();

            Assert.Equal("279138", result);
        }
    }
}