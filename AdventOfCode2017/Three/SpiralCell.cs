namespace AdventOfCode2017.Three
{
    public class SpiralCell
    {
        public int XCoord { get; set; }

        public int YCoord { get; set; }

        public int Value { get; set; }

        public bool IsCorner { get; set; }

        public SpiralCell(int x, int y, int value, bool isCorner)
        {
            XCoord = x;
            YCoord = y;
            Value = value;
            IsCorner = isCorner;
        }
    }
}