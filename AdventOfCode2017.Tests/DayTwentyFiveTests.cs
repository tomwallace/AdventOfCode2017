using AdventOfCode2017.TwentyFive;
using System.Collections.Generic;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class DayTwentyFiveTests
    {
        [Fact]
        public void TestCalculateDiagnosticChecksum()
        {
            TuringState a = new TuringState(false, true, -1, 1, "B", "B");
            TuringState b = new TuringState(true, true, 1, -1, "A", "A");
            Dictionary<string, TuringState> states = new Dictionary<string, TuringState>();
            states.Add("A", a);
            states.Add("B", b);

            var sut = new DayTwentyFive();
            var result = sut.CalculateDiagnosticChecksum(states, 6, "A");

            Assert.Equal(3, result);
        }

        [Fact]
        public void TestPartA()
        {
            var sut = new DayTwentyFive();
            var result = sut.PartA();

            Assert.Equal("3554", result);
        }

        // No Part B for DayTwentyFive - need to get all the other stars.
    }
}