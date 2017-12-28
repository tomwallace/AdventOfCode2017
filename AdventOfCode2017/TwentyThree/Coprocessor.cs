using System.Collections.Generic;

namespace AdventOfCode2017.TwentyThree
{
    public class Coprocessor
    {
        public Dictionary<string, long> Registers { get; set; }

        public int CurrentInstruction { get; set; }

        public Coprocessor()
        {
            Registers = new Dictionary<string, long>();
            CurrentInstruction = 0;
        }
    }
}