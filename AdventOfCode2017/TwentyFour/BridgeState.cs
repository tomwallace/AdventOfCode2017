using System.Collections.Generic;

namespace AdventOfCode2017.TwentyFour
{
    public class BridgeState
    {
        public Component Current { get; set; }

        public int OpenPort { get; set; }

        public List<int> UsedIds { get; set; }

        public int TotalStrength { get; set; }

        public int TotalLength { get; set; }

        public BridgeState()
        {
            UsedIds = new List<int>();
        }
    }
}