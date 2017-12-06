using System.Collections.Generic;
using System.Linq;
using AdventOfCode2017.Six;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class DaySixTests
    {
        [Fact]
        public void TestNumberOfStepsUntilDuplicateState()
        {
            int[] initialBlocks = new[] {0, 2, 7, 0};
            var sut = new DaySix();
            var result = sut.NumberOfStepsUntilDuplicateState(initialBlocks);

            Assert.Equal(5, result);
        }

        [Fact]
        public void TestNumberOfStepsBetweenFirstDuplicate()
        {
            int[] initialBlocks = new[] { 0, 2, 7, 0 };
            var sut = new DaySix();
            var result = sut.NumberOfStepsBetweenFirstDuplicate(initialBlocks);

            Assert.Equal(4, result);
        }

        [Fact]
        public void TestMemoryModuleStateEquality()
        {
            var stateOne = new MemoryModuleState(new List<int>() {2, 4, 1, 2});
            var stateTwo = new MemoryModuleState(new List<int>() { 2, 4, 1, 2 });
            var stateThree = new MemoryModuleState(new List<int>() { 4, 1, 2, 2 });
            var list = new List<MemoryModuleState>() {stateOne, stateTwo, stateThree};
            Assert.Equal(3, list.Count);

            var uniqueList = list.Distinct().ToList();
            Assert.Equal(2, uniqueList.Count);
        }

        // Commenting out the tests below, as they are correct, but each take 2 minutes to run
        /*
        [Fact]
        public void testPartA()
        {
            var sut = new DaySix();
            var result = sut.PartA();

            Assert.Equal("3156", result);
        }

        [Fact]
        public void testPartB()
        {
            var sut = new DaySix();
            var result = sut.PartB();

            Assert.Equal("1610", result);
        }
        */
    }
}