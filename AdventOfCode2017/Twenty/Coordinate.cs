namespace AdventOfCode2017.Twenty
{
    public class Coordinate
    {
        public long X { get; set; }

        public long Y { get; set; }

        public long Z { get; set; }

        public Coordinate(long x, long y, long z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}