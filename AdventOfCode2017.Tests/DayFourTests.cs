using AdventOfCode2017.Four;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class DayFourTests
    {
        [Theory]
        [InlineData("aa bb cc dd ee", true)]
        [InlineData("aa bb cc dd aa", false)]
        [InlineData("aa bb cc dd aaa", true)]
        public void testIsValidPassPhrase_Duplicates(string input, bool expected)
        {
            var sut = new DayFour();
            var result = sut.IsValidPassPhrase_Duplicates(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("abcde fghij", true)]
        [InlineData("abcde xyz ecdab", false)]
        [InlineData("a ab abc abd abf abj", true)]
        [InlineData("iiii oiii ooii oooi oooo", true)]
        [InlineData("oiii ioii iioi iiio", false)]
        public void testIsValidPassPhrase_NoAnagrams(string input, bool expected)
        {
            var sut = new DayFour();
            var result = sut.IsValidPassPhrase_NoAnagrams(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void testNumberValidPassPhrases_PartA()
        {
            var sut = new DayFour();
            var result = sut.PartA();

            Assert.Equal("477", result);
        }

        [Fact]
        public void testNumberValidPassPhrases_PartB()
        {
            var sut = new DayFour();
            var result = sut.PartB();

            Assert.Equal("167", result);
        }
    }
}