using AdventOfCode2017.TwentyOne;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class DayTwentyOneTests
    {
        [Fact]
        public void TestPixelProgramCreationAndMethods()
        {
            var sut = new PixelProgram(DayTwentyOne.Start);
            Assert.Equal(DayTwentyOne.Start, sut.ToString());
            Assert.Equal(5, sut.PixelsTurnedOn());
            Assert.Equal(3, sut.Size());
        }

        [Theory]
        [InlineData(".#./..#/###")]
        [InlineData(".#./#../###")]
        [InlineData("#../#.#/##.")]
        [InlineData("###/#../.#.")]
        [InlineData(".##/#.#/..#")]
        public void TestAllRotationsAndFlips(string included)
        {
            var sut = new PixelProgram(DayTwentyOne.Start);
            var result = sut.AllRotationsAndFlips();
            Assert.True(result.Contains(included));
        }
        
        [Fact]
        public void TestSplit_Three()
        {
            var sut = new PixelProgram(DayTwentyOne.Start);
            var result = sut.Split();
            Assert.Equal(1, result.Count);
            Assert.Equal(".#./..#/###", result[0][0].ToString());
        }

        [Fact]
        public void TestSplit_Two()
        {
            var sut = new PixelProgram(".#.#/..#./###./....");
            var result = sut.Split();
            Assert.Equal(2, result.Count);
            Assert.Equal(".#/..", result[0][0].ToString());
            Assert.Equal(".#/#.", result[0][1].ToString());
            Assert.Equal("##/..", result[1][0].ToString());
            Assert.Equal("#./..", result[1][1].ToString());
        }

        [Fact]
        public void TestTransformArtAndCountPizelsTurnedOn()
        {
            string filePath = @"TwentyOne\DayTwentyOneTestInput.txt";
            var sut = new DayTwentyOne();
            var result = sut.TransformArtAndCountPizelsTurnedOn(filePath, 2);
            Assert.Equal(12, result);
        }

        [Fact]
        public void TestPartA()
        {
            var sut = new DayTwentyOne();
            var result = sut.PartA();

            Assert.Equal("144", result);
        }

        [Fact]
        public void TestPartB()
        {
            var sut = new DayTwentyOne();
            var result = sut.PartB();

            Assert.Equal("2169301", result);
        }
    }
}