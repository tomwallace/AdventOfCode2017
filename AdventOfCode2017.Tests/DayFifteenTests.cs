using AdventOfCode2017.Fifteen;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class DayFifteenTests
    {
        [Fact]
        public void TestGenerator()
        {
            var genA = new Generator(65, DayFifteen.GeneratorAFactor, 1);
            var genANextValue = genA.NextValue();
            Assert.Equal(1092455, genANextValue);
            var genABinary = genA.CurrentBinary();
            Assert.Equal("00000000000100001010101101100111", genABinary);

            var genB = new Generator(8921, DayFifteen.GeneratorBFactor, 1);
            var genBNextValue = genB.NextValue();
            Assert.Equal(430625591, genBNextValue);
            var genBBinary = genB.CurrentBinary();
            Assert.Equal("00011001101010101101001100110111", genBBinary);

            Assert.False(genA.IsEqual(genB));
        }

        [Fact]
        public void TestGeneratorA()
        {
            var genA = new Generator(65, DayFifteen.GeneratorAFactor, 1);
            Assert.Equal(1092455, genA.NextValue());
            Assert.Equal("00000000000100001010101101100111", genA.CurrentBinary());

            Assert.Equal(1181022009, genA.NextValue());
            Assert.Equal("01000110011001001111011100111001", genA.CurrentBinary());

            Assert.Equal(245556042, genA.NextValue());
            Assert.Equal("00001110101000101110001101001010", genA.CurrentBinary());

            Assert.Equal(1744312007, genA.NextValue());
            Assert.Equal("01100111111110000001011011000111", genA.CurrentBinary());

            Assert.Equal(1352636452, genA.NextValue());
            Assert.Equal("01010000100111111001100000100100", genA.CurrentBinary());
        }

        // Takes 50 sec to run, so only uncomment if needed
        /*
        [Fact]
        public void TestNumberOfMatches()
        {
            var pairs = new GeneratorStartingValuePair() {GeneratorA = 65, GeneratorB = 8921};
            var sut = new DayFifteen();
            var result = sut.NumberOfMatches(pairs);

            Assert.Equal(588, result);
        }
        */

        // Takes 43 sec to run, so only uncomment if needed
        /*
        [Fact]
        public void TestNumberOfMatches()
        {
            var pairs = new GeneratorStartingValuePair() { GeneratorA = 65, GeneratorB = 8921 };
            var sut = new DayFifteen();
            var result = sut.NumberOfMatchesJudgeWait(pairs);

            Assert.Equal(309, result);
        }
        */

        // Takes 58 sec to run, so only uncomment if needed
        /*
        [Fact]
        public void TestPartA()
        {
            var sut = new DayFifteen();
            var result = sut.PartA();

            Assert.Equal("573", result);
        }
        */

        // Takes 45 sec to run, so only uncomment if needed
        /*
        [Fact]
        public void TestPartB()
        {
            var sut = new DayFifteen();
            var result = sut.PartB();

            Assert.Equal("294", result);
        }
        */
    }
}