using System.Diagnostics;
using AdventOfCode2017.Seventeen;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class DaySeventeenTests
    {
        [Fact]
        public void TestSpinLock()
        {
            var sut = new SpinLock(3);
            var result = sut.IterateAndValueOfNextIndex(1);
            Assert.Equal("01", sut.ToString());
            Assert.Equal(0, result);

            result = sut.IterateAndValueOfNextIndex(2);
            Assert.Equal("021", sut.ToString());
            Assert.Equal(1, result);

            result = sut.IterateAndValueOfNextIndex(3);
            Assert.Equal("0231", sut.ToString());
            Assert.Equal(1, result);
        }


        [Theory]
        [InlineData(4, 3, 2)]
        [InlineData(8, 3, 5)]
        [InlineData(100, 3, 16)]
        public void TestModifiedSpinLock(int numberIterations, int steps, int expected)
        {
            SpinLockSingleIndex spinLockSingleIndex = new SpinLockSingleIndex(steps, 1);
            var result = spinLockSingleIndex.Calculate(numberIterations);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestIterateSpinLock()
        {
            var sut = new DaySeventeen();
            var result = sut.IterateSpinLock(3);

            Assert.Equal(638, result);
        }

        [Fact]
        public void TestPartA()
        {
            var sut = new DaySeventeen();
            var result = sut.PartA();

            Assert.Equal("417", result);
        }

        [Fact]
        public void TestPartB()
        {
            var sut = new DaySeventeen();
            var result = sut.PartB();

            Assert.Equal("34334221", result);
        }
    }
}