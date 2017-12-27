using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2017.TwentyTwo
{
    public class DayTwentyTwo : IAdventProblemSet
    {
        public string Description()
        {
            return "Sporifica Virus";
        }

        public int SortOrder()
        {
            return 22;
        }

        public string PartA()
        {
            string filePath = @"TwentyTwo\DayTwentyTwoInput.txt";
            return CountInfectionActionsInCluster(filePath, 12, false, 10000).ToString();
        }

        public string PartB()
        {
            string filePath = @"TwentyTwo\DayTwentyTwoInput.txt";
            return CountInfectionActionsInCluster(filePath, 12, true, 10000000).ToString();
        }

        public int CountInfectionActionsInCluster(string filePath, int center, bool isResistant, int iterations)
        {
            Dictionary<string, Node> cluster = CreateCluster(filePath, isResistant);
            int currX = center;
            int currY = center;
            Direction direction = new Direction(2);

            int infectionActions = 0;

            int counter = 0;
            do
            {
                string currentKey = $"{currY},{currX}";
                if (!cluster.ContainsKey(currentKey))
                    cluster.Add(currentKey, new Node('.', isResistant));

                direction.ChangeDirection(cluster[currentKey].GetState());

                cluster[currentKey].Interact();

                if (cluster[currentKey].IsInfected())
                    infectionActions++;

                currY += direction.ModifyYCoord();
                currX += direction.ModifyXCoord();

                counter++;
            } while (counter < iterations);

            return infectionActions;
        }

        private Dictionary<string, Node> CreateCluster(string filePath, bool isResistant)
        {
            Dictionary<string, Node> cluster = new Dictionary<string, Node>();

            string line;
            int row = 0;
            StreamReader file = new StreamReader(filePath);

            // Iterate over each line in the input
            while ((line = file.ReadLine()) != null)
            {
                char[] lineSplit = line.ToCharArray();
                for (int x = 0; x < lineSplit.Length; x++)
                {
                    cluster.Add($"{row},{x}", new Node(lineSplit[x], isResistant));
                }

                row++;
            }
            file.Close();

            return cluster;
        }
    }
}