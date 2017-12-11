using System;

namespace AdventOfCode2017.Eleven
{
    public class HexMap
    {
        public Hex Current { get; set; }

        public Hex Move(string dir)
        {
            switch (dir)
            {
                case "n":
                    if (Current.N == null)
                    {
                        Current.N = new Hex();
                        Current.N.YAxis = Current.YAxis + 1;
                        Current.N.XAxis = Current.XAxis;
                        Current.N.ZAxis = Current.ZAxis - 1;
                        Current.N.S = Current;
                    }
                    return Current.N;

                case "ne":
                    if (Current.Ne == null)
                    {
                        Current.Ne = new Hex();
                        Current.Ne.YAxis = Current.YAxis;
                        Current.Ne.XAxis = Current.XAxis + 1;
                        Current.Ne.ZAxis = Current.ZAxis - 1;
                        Current.Ne.Sw = Current;
                    }
                    return Current.Ne;

                case "se":
                    if (Current.Se == null)
                    {
                        Current.Se = new Hex();
                        Current.Se.YAxis = Current.YAxis - 1;
                        Current.Se.XAxis = Current.XAxis + 1;
                        Current.Se.ZAxis = Current.ZAxis;
                        Current.Se.Nw = Current;
                    }
                    return Current.Se;

                case "s":
                    if (Current.S == null)
                    {
                        Current.S = new Hex();
                        Current.S.YAxis = Current.YAxis - 1;
                        Current.S.XAxis = Current.XAxis;
                        Current.S.ZAxis = Current.ZAxis + 1;
                        Current.S.N = Current;
                    }
                    return Current.S;

                case "sw":
                    if (Current.Sw == null)
                    {
                        Current.Sw = new Hex();
                        Current.Sw.YAxis = Current.YAxis;
                        Current.Sw.XAxis = Current.XAxis - 1;
                        Current.Sw.ZAxis = Current.ZAxis + 1;
                        Current.Sw.Ne = Current;
                    }
                    return Current.Sw;

                case "nw":
                    if (Current.Nw == null)
                    {
                        Current.Nw = new Hex();
                        Current.Nw.YAxis = Current.YAxis + 1;
                        Current.Nw.XAxis = Current.XAxis - 1;
                        Current.Nw.ZAxis = Current.ZAxis;
                        Current.Nw.Se = Current;
                    }
                    return Current.Nw;

                default:
                    throw new ArgumentException("Not defined direction");
            }
        }

        public int GetSteps()
        {
            return (Math.Abs(Current.YAxis) + Math.Abs(Current.XAxis) + Math.Abs(Current.ZAxis)) / 2;
        }
    }
}