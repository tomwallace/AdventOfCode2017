using System.Collections.Generic;

namespace AdventOfCode2017.Ten
{
    public class KnotHashState
    {
        public List<int> Elements { get; set; }

        public int CurrentPosition { get; set; }

        public int SkipSize { get; set; }

        public KnotHashState(List<int> elements, int currentPosition, int skipSize)
        {
            Elements = elements;
            CurrentPosition = currentPosition;
            SkipSize = skipSize;
        }
    }
}