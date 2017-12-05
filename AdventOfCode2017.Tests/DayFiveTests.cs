using AdventOfCode2017.Five;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class DayFiveTests
    {
        [Fact]
        public void testCountNumberOfSteps()
        {
            int[] input = new[] {0, 3, 0, 1, -3};
            var sut = new DayFive();
            var result = sut.CountNumberOfSteps(input);

            Assert.Equal(5, result);
        }

        [Fact]
        public void testCountNumberOfStepsComplex()
        {
            int[] input = new[] { 0, 3, 0, 1, -3 };
            var sut = new DayFive();
            var result = sut.CountNumberOfStepsComplex(input);

            Assert.Equal(10, result);
        }

        [Fact]
        public void testPartA()
        {
            var sut = new DayFive();
            var result = sut.PartA();

            Assert.Equal("372671", result);
        }

        [Fact]
        public void testPartB()
        {
            var sut = new DayFive();
            var result = sut.PartB();

            Assert.Equal("25608480", result);
        }
    }
}