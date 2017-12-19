using AdventOfCode2017.Sixteen;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class DaySixteenTests
    {
        [Theory]
        [InlineData(1, "eabcd")]
        [InlineData(2, "deabc")]
        [InlineData(3, "cdeab")]
        [InlineData(4, "bcdea")]
        [InlineData(5, "abcde")]
        public void TestSpin(int steps, string expected)
        {
            var sut = new Spin($"s{steps}");
            var dancers = "abcde";
            var result = sut.Execute(dancers);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestPartner()
        {
            var sut = new Partner("pe/b");
            var dancers = "abcde";
            var result = sut.Execute(dancers);

            Assert.Equal("aecdb", result);
        }

        [Fact]
        public void TestExchange()
        {
            var sut = new Exchange("x3/4");
            var dancers = "abcde";
            var result = sut.Execute(dancers);

            Assert.Equal("abced", result);
        }

        [Fact]
        public void TestExecuteDance()
        {
            var dancers = "abcde";
            string danceMoves = "s1,x3/4,pe/b";
            var sut = new DaySixteen();
            var result = sut.ExecuteDance(dancers, danceMoves);

            Assert.Equal("baedc", result);
        }

        [Fact]
        public void TestPartA()
        {
            var sut = new DaySixteen();
            var result = sut.PartA();

            Assert.Equal("cgpfhdnambekjiol", result);
        }

        // Takes over 9 minutes, so only uncomment if necessary.
        /*
        [Fact]
        public void TestPartB()
        {
            var sut = new DaySixteen();
            var result = sut.PartB();

            Assert.Equal("gjmiofcnaehpdlbk", result);
        }
        */
    }
}