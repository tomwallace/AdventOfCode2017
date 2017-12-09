using AdventOfCode2017.Nine;
using System.Linq;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class DayNineTests
    {
        [Theory]
        [InlineData("{}", 1)]
        [InlineData("{{}}", 3)]
        [InlineData("{{{}}}", 6)]
        [InlineData("{{},{}}", 5)]
        [InlineData("{{{},{},{{}}}}", 16)]
        [InlineData("{<a>,<a>,<a>,<a>}", 1)]
        [InlineData("{{<ab>},{<ab>},{<ab>},{<ab>}}", 9)]
        [InlineData("{{<!!>},{<!!>},{<!!>},{<!!>}}", 9)]
        [InlineData("{{<a!>},{<a!>},{<a!>},{<ab>}}", 3)]
        public void TestParseStringAndReturn_TotalScore(string input, int totalScore)
        {
            var sut = new DayNine();
            var result = sut.ParseStringAndReturn(input).TotalScore;

            Assert.Equal(totalScore, result);
        }

        [Theory]
        [InlineData("<>", 0)]
        [InlineData("<random characters>", 17)]
        [InlineData("<<<<>", 3)]
        [InlineData("<{!>}>", 2)]
        [InlineData("<!!>", 0)]
        [InlineData("<!!!>>", 0)]
        public void TestParseStringAndReturn_GarbageScore(string input, int totalScore)
        {
            var sut = new DayNine();
            var result = sut.ParseStringAndReturn(input).GarbageScore;

            Assert.Equal(totalScore, result);
        }

        [Fact]
        public void TestPartA()
        {
            var sut = new DayNine();
            var result = sut.PartA();

            Assert.Equal("16021", result);
        }

        [Fact]
        public void TestPartB()
        {
            var sut = new DayNine();
            var result = sut.PartB();

            Assert.Equal("7685", result);
        }
    }
}