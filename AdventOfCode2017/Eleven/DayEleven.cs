using System.IO;

namespace AdventOfCode2017.Eleven
{
    public class DayEleven : IAdventProblemSet
    {
        public string Description()
        {
            return "Hex Ed";
        }

        public int SortOrder()
        {
            return 11;
        }

        public string PartA()
        {
            string line;
            int steps = 0;
            StreamReader file = new StreamReader(@"Eleven\DayElevenInput.txt");

            // Iterate over each line in the input
            while ((line = file.ReadLine()) != null)
            {
                // Only one line in this input file
                steps = CalculateSteps(line).EndSteps;
            }
            file.Close();

            return steps.ToString();
        }

        public string PartB()
        {
            string line;
            int maxStepsAway = 0;
            StreamReader file = new StreamReader(@"Eleven\DayElevenInput.txt");

            // Iterate over each line in the input
            while ((line = file.ReadLine()) != null)
            {
                // Only one line in this input file
                maxStepsAway = CalculateSteps(line).MaxStepsAway;
            }
            file.Close();

            return maxStepsAway.ToString();
        }

        public HexMapResults CalculateSteps(string moves)
        {
            string[] movesSplit = moves.Split(',');
            Hex start = new Hex() { YAxis = 0, XAxis = 0, ZAxis = 0 };
            HexMap map = new HexMap();
            map.Current = start;

            int maxSteps = 0;

            foreach (string move in movesSplit)
            {
                map.Current = map.Move(move);
                int currentSteps = map.GetSteps();
                if (currentSteps > maxSteps)
                    maxSteps = currentSteps;
            }

            int endSteps = map.GetSteps();

            return new HexMapResults(endSteps, maxSteps);
        }
    }
}