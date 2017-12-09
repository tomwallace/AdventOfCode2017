using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Nine
{
    public class DayNine : IAdventProblemSet
    {
        public static readonly int Input = 277678;

        public string Description()
        {
            return "Stream Processing";
        }

        public int SortOrder()
        {
            return 3;
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
            int startGarbage = -1;
            int garbageScore = 0;

            while (currentPointer < inputSplit.Count)
            {
                char currentChar = inputSplit[currentPointer];
                if (currentChar == '!' && startGarbage > -1)
                {
                    inputSplit.RemoveAt(currentPointer + 1);
                }
                else
                {
                    if (currentChar != '>' && startGarbage > -1)
                        garbageScore++;

                    if (currentChar == '<' && startGarbage == -1)
                        startGarbage = currentPointer;

                    if (currentChar == '>')
                        startGarbage = -1;

                    if (currentChar == '{' && startGarbage == -1)
                        groupScore++;

                    if (currentChar == '}' && startGarbage == -1)
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