using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2017.TwentyThree
{
    public class DayTwentyThree : IAdventProblemSet
    {
        public string Description()
        {
            return "Coprocessor Conflagration (HARD)";
        }

        public int SortOrder()
        {
            return 23;
        }

        public string PartA()
        {
            string filePath = @"TwentyThree\DayTwentyThreeInput.txt";
            return RunThroughInstructionsAndCountMult(filePath).ToString();
        }

        public string PartB()
        {
            return RunConsolidatedInstructions().ToString();
        }

        public int RunThroughInstructionsAndCountMult(string filePath)
        {
            List<string> instructions = GetInstructions(filePath);

            Coprocessor coprocessor = new Coprocessor();
            int count = 0;
            do
            {
                string instruction = instructions[coprocessor.CurrentInstruction];
                count += ProcessInstruction(instruction, coprocessor);
                coprocessor.CurrentInstruction++;
            } while (coprocessor.CurrentInstruction < 32);  // 32 is lines in current program

            return count;
        }

        public int RunConsolidatedInstructions()
        {
            // I really struggled with this solution.  Some helpful hints on the Reddit thread for Day 23 got me thinking about the problem as a refactoring.
            // The result is below, having removed and simplified the loops.  However, the processing was still going very slow until I read a few other posts
            // that hinted at a way to limit the code in the inner loops to look for the first time the two variables did not have a remainder.  That made things
            // go much faster.  Thanks to pleasant-trip for outlining a refactoring way forward and to BOT-Brad for showing the way to refactor the inner loops.
            int b = 109900;
            int c = 126900;
            int h = 0;

            while (true)
            {
                bool f = false;
                int d = 2;

                while (d < b)
                {
                    if (b % d == 0)
                    {
                        f = true;
                        break;
                    }
                    d++;
                }

                if (f) h++;
                if (b == c)
                    return h;
                b += 17;
            }
        }

        public int ProcessInstruction(string command, Coprocessor coprocessor)
        {
            string[] commandSplit = command.Split(' ');
            switch (commandSplit[0])
            {
                case "set":
                    DetermineValue(commandSplit[1], coprocessor);
                    coprocessor.Registers[commandSplit[1]] = DetermineValue(commandSplit[2], coprocessor);
                    break;

                case "sub":
                    DetermineValue(commandSplit[1], coprocessor);
                    coprocessor.Registers[commandSplit[1]] -= DetermineValue(commandSplit[2], coprocessor);
                    break;

                case "mul":
                    DetermineValue(commandSplit[1], coprocessor);
                    coprocessor.Registers[commandSplit[1]] = coprocessor.Registers[commandSplit[1]] * DetermineValue(commandSplit[2], coprocessor);
                    return 1;

                case "jnz":
                    long firstValue = DetermineValue(commandSplit[1], coprocessor);
                    if (firstValue != 0)
                        coprocessor.CurrentInstruction += (int)DetermineValue(commandSplit[2], coprocessor) - 1;
                    break;

                default:
                    throw new ArgumentException("Unknown command");
            }

            return 0;
        }

        private long DetermineValue(string value, Coprocessor coprocessor)
        {
            long result;
            if (long.TryParse(value, out result))
                return result;

            long found = FindRegisterValueOrCreateNew(value, coprocessor);
            return found;
        }

        private long FindRegisterValueOrCreateNew(string key, Coprocessor coprocessor)
        {
            if (coprocessor.Registers.ContainsKey(key))
                return coprocessor.Registers[key];

            coprocessor.Registers.Add(key, 0);
            return 0;
        }

        private List<string> GetInstructions(string filePath)
        {
            List<string> instructions = new List<string>();
            string line;
            StreamReader file = new StreamReader(filePath);

            // Iterate over each line in the input
            while ((line = file.ReadLine()) != null)
            {
                instructions.Add(line);
            }
            file.Close();
            return instructions;
        }
    }
}