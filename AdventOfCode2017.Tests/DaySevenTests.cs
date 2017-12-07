using AdventOfCode2017.Seven;
using System.Collections.Generic;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class DaySevenTests
    {
        [Fact]
        public void TestDiscConstructor_WithConnectedIds()
        {
            var inputWithConnectedIds = "fwft (72) -> ktlj, cntj, xhth";
            var discOne = new Disc(inputWithConnectedIds);
            Assert.Equal("fwft", discOne.Id);
            Assert.Equal(72, discOne.Weight);
            Assert.Equal(3, discOne.ConnectedDiscIds.Count);
            Assert.True(discOne.ConnectedDiscIds.Contains("ktlj"));
            Assert.True(discOne.ConnectedDiscIds.Contains("cntj"));
            Assert.True(discOne.ConnectedDiscIds.Contains("xhth"));
        }

        [Fact]
        public void TestDiscConstructor_NoConnections()
        {
            var inputWithConnectedIds = "ktlj (57)";
            var discOne = new Disc(inputWithConnectedIds);
            Assert.Equal("ktlj", discOne.Id);
            Assert.Equal(57, discOne.Weight);
            Assert.Equal(0, discOne.ConnectedDiscIds.Count);
        }

        [Fact]
        public void TestFindCircusRoot()
        {
            List<Disc> input = new List<Disc>()
            {
                new Disc ("pbga", 66, new List<string>()),
                new Disc ("xhth", 57, new List<string>()),
                new Disc ("ebii", 61, new List<string>()),
                new Disc ("havc", 66, new List<string>()),
                new Disc ("ktlj", 57, new List<string>()),
                new Disc ("fwft", 72, new List<string>() {"ktlj", "cntj", "xhth"}),
                new Disc ("qoyq", 66, new List<string>()),
                new Disc ("padx", 45, new List<string>() {"pbga", "havc", "qoyq"}),
                new Disc ("tknk", 41, new List<string>() {"ugml", "padx", "fwft"}),
                new Disc ("jptl", 61, new List<string>()),
                new Disc ("ugml", 68, new List<string>() {"gyxo", "ebii", "jptl"}),
                new Disc ("gyxo", 61, new List<string>()),
                new Disc ("cntj", 57, new List<string>())
            };

            var sut = new DaySeven();
            var result = sut.FindCircusRoot(input);

            Assert.Equal("tknk", result);
        }

        [Fact]
        public void TestProcessCircus()
        {
            List<Disc> input = new List<Disc>()
            {
                new Disc ("pbga", 66, new List<string>()),
                new Disc ("xhth", 57, new List<string>()),
                new Disc ("ebii", 61, new List<string>()),
                new Disc ("havc", 66, new List<string>()),
                new Disc ("ktlj", 57, new List<string>()),
                new Disc ("fwft", 72, new List<string>() {"ktlj", "cntj", "xhth"}),
                new Disc ("qoyq", 66, new List<string>()),
                new Disc ("padx", 45, new List<string>() {"pbga", "havc", "qoyq"}),
                new Disc ("tknk", 41, new List<string>() {"ugml", "padx", "fwft"}),
                new Disc ("jptl", 61, new List<string>()),
                new Disc ("ugml", 68, new List<string>() {"gyxo", "ebii", "jptl"}),
                new Disc ("gyxo", 61, new List<string>()),
                new Disc ("cntj", 57, new List<string>())
            };

            var sut = new DaySeven();
            var result = sut.ProcessCircus(input);

            Assert.Equal(60, result);
        }

        [Fact]
        public void TestPartA()
        {
            var sut = new DaySeven();
            var result = sut.PartA();

            Assert.Equal("vgzejbd", result);
        }

        [Fact]
        public void TestPartB()
        {
            var sut = new DaySeven();
            var result = sut.PartB();

            Assert.Equal("1226", result);
        }
    }
}