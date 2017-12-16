using AdventOfCode2017.Ten;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class DayTenTests
    {
        [Fact]
        public void TestCalculateKnotHash()
        {
            List<int> inputs = new List<int>() { 3, 4, 1, 5 };
            var knotSize = 5;
            List<int> elements = Enumerable.Range(0, knotSize).ToList();
            KnotHashState previousState = new KnotHashState(elements, 0, 0);

            var sut = new KnotHash();
            var result = sut.CalculateKnotHash(previousState, inputs);
            var mult = result.Elements[0] * result.Elements[1];

            Assert.Equal(12, mult);
        }

        [Fact]
        public void TestToAscii()
        {
            List<int> list = new List<int>() { 1, 2, 3 };
            var sut = new KnotHash();
            var result = sut.ToAsciiCode(list);

            Assert.Equal(new List<int>() { 49, 44, 50, 44, 51 }, result);
        }

        [Fact]
        public void TestToDenseHash()
        {
            List<int> sparseHash = new List<int>() { 65, 27, 9, 1, 4, 3, 40, 50, 91, 7, 6, 0, 2, 5, 68, 22 };
            var sut = new KnotHash();
            var result = sut.ToDenseHash(sparseHash, 16);

            Assert.Equal(64, result.First());
        }

        [Fact]
        public void TestToHexString()
        {
            List<int> denseHash = new List<int>() { 64, 7, 255 };
            var sut = new KnotHash();
            var result = sut.ToHexString(denseHash);

            Assert.Equal("4007ff", result);
        }

        [Fact]
        public void TestToHexString_Real()
        {
            List<int> denseHash = new List<int>() { 12, 47, 121, 75, 46, 181, 85, 247, 131, 7, 102, 191, 143, 182, 90, 22 };
            var sut = new KnotHash();
            var result = sut.ToHexString(denseHash);

            Assert.Equal(32, result.Length);
            Assert.Equal("0c2f794b2eb555f7830766bf8fb65a16", result);
        }

        [Fact]
        public void TestKnotHash_string()
        {
            var dayTen = new DayTen();
            List<int> originalInput = dayTen.Input;
            string stringInput = string.Join<int>(",", originalInput);

            var knotHash = new KnotHash(stringInput);
            Assert.Equal(32, knotHash.HexOutput.Length);
            Assert.Equal("0c2f794b2eb555f7830766bf8fb65a16", knotHash.HexOutput);
        }

        [Fact]
        public void TestPartA()
        {
            var sut = new DayTen();
            var result = sut.PartA();

            Assert.Equal("2928", result);
        }

        [Fact]
        public void TestPartB()
        {
            var sut = new DayTen();
            var result = sut.PartB();

            Assert.Equal(32, result.Length);
            Assert.Equal("0c2f794b2eb555f7830766bf8fb65a16", result);
        }
    }
}