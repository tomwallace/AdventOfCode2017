using Xunit;

namespace AdventOfCode2017.Tests
{
    public class DayThreeTests
    {
        [Theory]
        [InlineData(1, 1, 1, 0, 0)]
        [InlineData(12, 4, 4, 0, 3)]
        [InlineData(13, 4, 4, 0, 0)]
        [InlineData(22, 6, 5, 2, 0)]
        [InlineData(26, 6, 5, 0, 0)]
        public void testSpiralGrid_SetDimensions(long steps, long expectedWidth, long expectedHeight, long expectedPartialWidth, long expectedPartialHeight)
        {
            var spiralGrid = new SpiralGrid(steps);
            Assert.Equal(expectedWidth, spiralGrid.Width);
            Assert.Equal(expectedHeight, spiralGrid.Height);
            // TODO: Fix these values
            //Assert.Equal(expectedPartialWidth, spiralGrid.PartialWidth);
            //Assert.Equal(expectedPartialHeight, spiralGrid.PartialHeight);
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(12, 3)]
        [InlineData(13, 4)]
        [InlineData(23, 2)]
        [InlineData(1024, 31)]
        [InlineData(277678, 475)]
        public void testSpiralGrid_ManhattanDistance(long steps, long expectedDist)
        {
            var spiralGrid = new SpiralGrid(steps);
            Assert.Equal(expectedDist, spiralGrid.ManhattanDistance());
        }
    }
}