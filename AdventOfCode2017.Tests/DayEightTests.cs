using AdventOfCode2017.Eight;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class DayEightTests
    {
        [Fact]
        public void TestFindLargestRegisterValue()
        {
            var path = @"Eight\DayEightTestInput.txt";
            var sut = new DayEight();
            var result = sut.FindLargestRegisterValue(path);

            Assert.Equal(1, result);
        }

        [Fact]
        public void TestFindLargestRegisterValueAtAnyPoint()
        {
            var path = @"Eight\DayEightTestInput.txt";
            var sut = new DayEight();
            var result = sut.FindLargestRegisterValueAtAnyPoint(path);

            Assert.Equal(10, result);
        }

        [Fact]
        public void TestPartA()
        {
            var sut = new DayEight();
            var result = sut.PartA();

            Assert.Equal("4877", result);
        }

        [Fact]
        public void TestPartB()
        {
            var sut = new DayEight();
            var result = sut.PartB();

            Assert.Equal("5471", result);
        }
    }
}