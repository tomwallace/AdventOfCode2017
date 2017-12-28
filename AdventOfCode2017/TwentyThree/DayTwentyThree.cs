using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace AdventOfCode2017.TwentyThree
{
    public class DayTwentyThree : IAdventProblemSet
    {
        public string Description()
        {
            return "Coprocessor Conflagration";
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
            string filePath = @"TwentyThree\DayTwentyThreeInput.txt";
            return DetermineRegisterH(filePath).ToString();
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

        public long DetermineRegisterH(string filePath)
        {
            List<string> instructions = GetInstructions(filePath);

            Coprocessor coprocessor = new Coprocessor();

            // Register A starts at 1 now
            coprocessor.Registers.Add("a", 1);

            do
            {
                string instruction = instructions[coprocessor.CurrentInstruction];
                //Debug.WriteLine($"Instruction[{coprocessor.CurrentInstruction}]: {instruction}");

                ProcessInstruction(instruction, coprocessor);
                coprocessor.CurrentInstruction++;

            } while (coprocessor.CurrentInstruction < 32);  // 32 is lines in current program

            return coprocessor.Registers["h"];
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

    public class Coprocessor
    {
        public Dictionary<string, long> Registers { get; set; }

        public int CurrentInstruction { get; set; }

        public Coprocessor()
        {
            Registers = new Dictionary<string, long>();
            CurrentInstruction = 0;
        }
    }
}