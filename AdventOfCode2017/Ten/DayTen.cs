using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017.Ten
{
    public class DayTen : IAdventProblemSet
    {
        public List<int> Input = new List<int>() { 230, 1, 2, 221, 97, 252, 168, 169, 57, 99, 0, 254, 181, 255, 235, 167 };

        public string Description()
        {
            return "Knot Hash (HARD)";
        }

        public int SortOrder()
        {
            return 10;
        }

        public string PartA()
        {
            List<int> elements = Enumerable.Range(0, 256).ToList();
            KnotHashState previousState = new KnotHashState(elements, 0, 0);

            KnotHash knotHash = new KnotHash();
            KnotHashState newState = knotHash.CalculateKnotHash(previousState, Input);
            int mult = newState.Elements[0] * newState.Elements[1];

            return mult.ToString();
        }

        public string PartB()
        {
            KnotHash knotHash = new KnotHash(Input);
            return knotHash.HexOutput;
        }
    }
}