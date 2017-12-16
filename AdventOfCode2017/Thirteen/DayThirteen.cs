using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Thirteen
{
    public class DayThirteen : IAdventProblemSet
    {
        public string Description()
        {
            return "Packet Scanners (HARD)";
        }

        public int SortOrder()
        {
            return 13;
        }

        public string PartA()
        {
            string filePath = @"Thirteen\DayThirteenInput.txt";
            return CalculateTripSeverity(filePath).ToString();
        }

        public string PartB()
        {
            string filePath = @"Thirteen\DayThirteenInput.txt";
            return CalculateMinDelayForSafePassage(filePath).ToString();
        }

        public int CalculateTripSeverity(string filePath)
        {
            List<Layer> firewall = CreateFirewall(filePath);

            int totalSeverity = 0;

            foreach (Layer layer in firewall)
            {
                if (layer.IsCaught())
                    totalSeverity += layer.Severity();

                foreach (Layer toAdvance in firewall)
                    toAdvance.Advance();
            }

            return totalSeverity;
        }

        public int CalculateMinDelayForSafePassage(string filePath)
        {
            int delay = 1;
            bool madeItThrough = false;
            List<Layer> firewall = CreateFirewall(filePath);

            // NOTE - I had to change this to a mathmatical solution, rather than using what I
            // modeled in Part A, as extending that for Part B did not solve after 4 hours of running.
            List<int> stepsToCircuit = firewall.Select(l => (l.Range - 1) * 2).ToList();
            do
            {
                bool localSuccess = true;
                int counter = 0;
                foreach (int steps in stepsToCircuit)
                {
                    // This skips past the layers that did not have a sentry
                    if (steps > 0)
                    {
                        // Factor in the depth steps, plus the packet steping through each layer in turn
                        double divided = ((double)delay / steps) + ((double)counter / steps);
                        // If the result is a whole number, then the scanner is at 0 and caught the packet
                        if (divided == (int)divided)
                        {
                            localSuccess = false;
                        }
                    }

                    counter++;
                }

                // The packet was not caught by any layer
                if (localSuccess)
                    madeItThrough = true;
                else
                    delay++;
            } while (!madeItThrough);

            return delay;
        }

        private List<Layer> CreateFirewall(string filePath)
        {
            List<Layer> firewall = new List<Layer>();
            int counter = 0;

            string line;
            StreamReader file = new StreamReader(filePath);

            // Iterate over each line in the input
            while ((line = file.ReadLine()) != null)
            {
                Layer layer = new Layer(line);
                while (layer.Id > counter)
                {
                    Layer empty = new Layer(counter);
                    firewall.Add(empty);
                    counter++;
                }
                firewall.Add(layer);
                counter++;
            }
            file.Close();
            return firewall;
        }
    }
}