using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2017.Five
{
    public class DayFive : IAdventProblemSet
    {
        public string Description()
        {
            return "A Maze of Twisty Trampolines, All Alike";
        }

        public int SortOrder()
        {
            return 5;
        }

        public string PartA()
        {
            int[] offsets = CollectOffsetsFromInput();
            return CountNumberOfSteps(offsets).ToString();
        }

        public string PartB()
        {
            int[] offsets = CollectOffsetsFromInput();
            return CountNumberOfStepsComplex(offsets).ToString();
        }

        public int CountNumberOfSteps(int[] offsets)
        {
            int pointer = 0;
            int steps = 0;

            while (pointer < offsets.Length)
            {
                int currentValue = offsets[pointer];
                offsets[pointer]++;
                pointer += currentValue;

                steps++;
            }

            return steps;
        }

        public int CountNumberOfStepsComplex(int[] offsets)
        {
            int pointer = 0;
            int steps = 0;

            while (pointer < offsets.Length)
            {
                int currentValue = offsets[pointer];
                if (currentValue >= 3)
                    offsets[pointer]--;
                else
                    offsets[pointer]++;

                pointer += currentValue;

                steps++;
            }

            return steps;
        }

        private int[] CollectOffsetsFromInput()
        {
            string line;
            StreamReader file = new StreamReader(@"Five\DayFiveInput.txt");

            List<int> offsets = new List<int>();
            // Iterate over each line in the input
            while ((line = file.ReadLine()) != null)
            {
                offsets.Add(Int32.Parse(line));
            }
            file.Close();

            return offsets.ToArray();
        }
    }
}