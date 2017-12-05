namespace AdventOfCode2017.Three
{
    public class DayThree : IAdventProblemSet
    {
        public static readonly int Input = 277678;

        public string Description()
        {
            return "Spiral Memory";
        }

        public int SortOrder()
        {
            return 3;
        }

        public string PartA()
        {
            var spiral = new SpiralGrid(Input);
            return spiral.ManhattanDistance().ToString();
        }

        public string PartB()
        {
            return CalculateNextCellValue(Input).ToString();
        }

        public int CalculateNextCellValue(int puzzleInput)
        {
            int output = 0;
            SpiralSummingGrid spiral = new SpiralSummingGrid();

            while (output <= puzzleInput)
            {
                output = spiral.AddCell();
            }

            return output;
        }
    }
}