using System;

namespace AdventOfCode2017
{
    public class DayOne
    {
        public int PartA(string input)
        {
            int total = 0;

            char[] split = input.ToCharArray();
            int splitSize = split.Length;

            for (int i = 0; i < splitSize; i++)
            {
                int convertedCurrent = Int32.Parse(split[i].ToString());
                int convertedNext;
                if (i == splitSize - 1)
                    convertedNext = Int32.Parse(split[0].ToString());
                else
                    convertedNext = Int32.Parse(split[i + 1].ToString());

                if (convertedCurrent == convertedNext)
                    total += convertedCurrent;
            }

            return total;
        }

        public int PartB(string input)
        {
            int total = 0;

            char[] split = input.ToCharArray();
            int splitSize = split.Length;
            int stepsForward = splitSize / 2;

            for (int i = 0; i < splitSize; i++)
            {
                int convertedCurrent = Int32.Parse(split[i].ToString());

                int convertedSteps = i + stepsForward;
                if (convertedSteps > (splitSize - 1))
                    convertedSteps = convertedSteps - splitSize;

                int convertedNext = Int32.Parse(split[convertedSteps].ToString());

                if (convertedCurrent == convertedNext)
                    total += convertedCurrent;
            }

            return total;
        }
    }
}