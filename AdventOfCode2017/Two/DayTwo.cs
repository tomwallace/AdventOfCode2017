using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Two
{
    public class DayTwo
    {
        public long CalculateChecksumA()
        {
            long runningCheckSum = 0;
            string line;
            StreamReader file = new StreamReader(@"Two\DayTwoInput.txt");

            // Iterate over each line in the input
            while ((line = file.ReadLine()) != null)
            {
                runningCheckSum += CalculateLineDifference(line);
            }
            file.Close();

            return runningCheckSum;
        }

        public decimal CalculateChecksumB()
        {
            decimal runningCheckSum = 0;
            string line;
            StreamReader file = new StreamReader(@"Two\DayTwoInput.txt");

            // Iterate over each line in the input
            while ((line = file.ReadLine()) != null)
            {
                runningCheckSum += CalculateLineEvenDivision(line);
            }
            file.Close();

            return runningCheckSum;
        }

        public long CalculateLineDifference(string line)
        {
            string[] lineSplit = line.Split('\t');
            int[] intSplit = Array.ConvertAll(lineSplit, int.Parse);

            return intSplit.Max() - intSplit.Min();
        }

        public decimal CalculateLineEvenDivision(string line)
        {
            string[] lineSplit = line.Split('\t');
            int[] intSplit = Array.ConvertAll(lineSplit, int.Parse);

            for (int x = 0; x < intSplit.Length; x++)
            {
                for (int y = 0; y < intSplit.Length; y++)
                {
                    decimal forward = (decimal)intSplit[x]/intSplit[y];
                    decimal backward = (decimal)intSplit[y]/intSplit[x];
                    if (x != y)
                    {
                        if ((forward % 1) == 0)
                            return forward;

                        if ((backward % 1) == 0)
                            return backward;
                    }
                }
            }

            throw new ArgumentException("None of the combinations evenly divide");
        }
    }
}