using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Nineteen
{
    public class DayNineteen : IAdventProblemSet
    {
        public string Description()
        {
            return "A Series of Tubes";
        }

        public int SortOrder()
        {
            return 19;
        }

        public string PartA()
        {
            string filePath = @"Nineteen\DayNineteenInput.txt";
            return NavigateMap(filePath).Letters;
        }

        public string PartB()
        {
            string filePath = @"Nineteen\DayNineteenInput.txt";
            return NavigateMap(filePath).NumberOfSteps.ToString();
        }

        public MapResults NavigateMap(string filePath)
        {
            List<List<char>> map = GetMap(filePath);

            int y = 0;
            int x = map[y].FindIndex(c => c == '|');
            Direction direction = new Direction(4);

            bool isTerminated = false;
            int steps = 0;
            List<char> letters = new List<char>();
            do
            {
                x += direction.ModifyXCoord();
                y += direction.ModifyYCoord();
                char nextStep = map[y][x];

                steps++;

                switch (nextStep)
                {
                    case '+':
                        direction.ChangeDirection(x, y, map);
                        isTerminated = direction.IsTerminated;
                        break;

                    case '|':
                    case '-':
                        break;

                    case ' ':
                        isTerminated = true;
                        break;

                    default:
                        letters.Add(nextStep);
                        break;
                }
            } while (!isTerminated);

            MapResults results = new MapResults();
            results.Letters = new string(letters.ToArray());
            results.NumberOfSteps = steps;
            return results;
        }

        private List<List<char>> GetMap(string filePath)
        {
            List<List<char>> instructions = new List<List<char>>();
            string line;
            StreamReader file = new StreamReader(filePath);

            // Iterate over each line in the input
            while ((line = file.ReadLine()) != null)
            {
                instructions.Add(line.ToCharArray().ToList());
            }
            file.Close();
            return instructions;
        }
    }
}