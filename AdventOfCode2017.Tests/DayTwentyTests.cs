using AdventOfCode2017.Twenty;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class DayTwentyTests
    {
        [Fact]
        public void TestIdOfClosestParticle()
        {
            string filePath = @"Twenty\DayTwentyTestInput.txt";
            var sut = new DayTwenty();
            var result = sut.IdOfClosestParticle(filePath);

            Assert.Equal(0, result);
        }

        [Fact]
        public void TestHowManyLeftAfterCollisions()
        {
            string filePath = @"Twenty\DayTwentyTestTwoInput.txt";
            var sut = new DayTwenty();
            var result = sut.HowManyLeftAfterCollisions(filePath);

            Assert.Equal(1, result);
        }

        [Fact]
        public void TestPartA()
        {
            var sut = new DayTwenty();
            var result = sut.PartA();

            Assert.Equal("364", result);
        }

        [Fact]
        public void TestPartB()
        {
            var sut = new DayTwenty();
            var result = sut.PartB();

            Assert.Equal("420", result);
        }
    }
}