using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017.Twelve
{
    public class Program
    {
        public int Id { get; }

        public List<int> ConnectedIds { get; }

        public Program(string input)
        {
            // ex: 2 <-> 0, 3, 4
            string[] inputSplitArrows = input.Split(new string[] { " <-> " }, StringSplitOptions.None);
            Id = Int32.Parse(inputSplitArrows[0].Trim());

            ConnectedIds = inputSplitArrows[1].Split(',').Select(x => Int32.Parse(x.Trim())).ToList();
        }
    }
}