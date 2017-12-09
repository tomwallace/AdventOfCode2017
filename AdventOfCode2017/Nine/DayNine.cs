using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Nine
{
    public class DayNine : IAdventProblemSet
    {
        public string Description()
        {
            return "Stream Processing";
        }

        public int SortOrder()
        {
            return 9;
        }

        public string PartA()
        {
            string line;
            int totalScore = 0;
            StreamReader file = new StreamReader(@"Nine\DayNineInput.txt");

            // Iterate over each line in the input
            while ((line = file.ReadLine()) != null)
            {
                // Only one line in this input file
                totalScore = ParseStringAndReturn(line).TotalScore;
            }
            file.Close();

            return totalScore.ToString();
        }

        public string PartB()
        {
            string line;
            int garbageScore = 0;
            StreamReader file = new StreamReader(@"Nine\DayNineInput.txt");

            // Iterate over each line in the input
            while ((line = file.ReadLine()) != null)
            {
                // Only one line in this input file
                garbageScore = ParseStringAndReturn(line).GarbageScore;
            }
            file.Close();

            return garbageScore.ToString();
        }

        public ParseResults ParseStringAndReturn(string input)
        {
            List<char> inputSplit = input.ToCharArray().ToList();
            int totalScore = 0;
            int groupScore = 0;
            int currentPointer = 0;
            bool inGarbage = false;
            int garbageScore = 0;

            while (currentPointer < inputSplit.Count)
            {
                char currentChar = inputSplit[currentPointer];
                if (currentChar == '!' && inGarbage)
                {
                    inputSplit.RemoveAt(currentPointer + 1);
                }
                else
                {
                    if (currentChar != '>' && inGarbage)
                        garbageScore++;

                    if (currentChar == '<' && !inGarbage)
                        inGarbage = true;

                    if (currentChar == '>')
                        inGarbage = false;

                    if (currentChar == '{' && !inGarbage)
                        groupScore++;

                    if (currentChar == '}' && !inGarbage)
                    {
                        totalScore += groupScore;
                        groupScore--;
                    }
                }

                currentPointer++;
            }

            return new ParseResults(totalScore, garbageScore);
        }
    }
}