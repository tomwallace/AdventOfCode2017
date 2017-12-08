using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Eight
{
    public class DayEight : IAdventProblemSet
    {
        public string Description()
        {
            return "I Heard You Like Registers";
        }

        public int SortOrder()
        {
            return 8;
        }

        public string PartA()
        {
            string filePath = @"Eight\DayEightInput.txt";
            int largest = FindLargestRegisterValue(filePath);
            return largest.ToString();
        }

        public string PartB()
        {
            string filePath = @"Eight\DayEightInput.txt";
            int largest = FindLargestRegisterValueAtAnyPoint(filePath);
            return largest.ToString();
        }

        public int FindLargestRegisterValue(string filePath)
        {
            List<Register> registers = new List<Register>();
            string line;
            StreamReader file = new StreamReader(filePath);

            // Iterate over each line in the input
            while ((line = file.ReadLine()) != null)
            {
                RegisterCommandAttributes attribs = new RegisterCommandAttributes(line);

                // if register does not exist, add it first
                if (!registers.Any(r => r.Name == attribs.RegisterName))
                    registers.Add(new Register(attribs.RegisterName));

                if (!registers.Any(r => r.Name == attribs.ConditionName))
                    registers.Add(new Register(attribs.ConditionName));

                IRegisterCommand command = new RegisterCommandBuilder().Build(attribs);
                if (command.IsApplicable(registers))
                {
                    Register appliesTo = command.AppliesToRegister(registers);
                    command.Execute(appliesTo);
                }
            }
            file.Close();

            int largestValue = registers.OrderByDescending(r => r.Value).First().Value;
            return largestValue;
        }

        public int FindLargestRegisterValueAtAnyPoint(string filePath)
        {
            List<Register> registers = new List<Register>();

            int largestValue = 0;

            string line;
            StreamReader file = new StreamReader(filePath);

            // Iterate over each line in the input
            while ((line = file.ReadLine()) != null)
            {
                RegisterCommandAttributes attribs = new RegisterCommandAttributes(line);

                // if register does not exist, add it first
                if (!registers.Any(r => r.Name == attribs.RegisterName))
                    registers.Add(new Register(attribs.RegisterName));

                if (!registers.Any(r => r.Name == attribs.ConditionName))
                    registers.Add(new Register(attribs.ConditionName));

                IRegisterCommand command = new RegisterCommandBuilder().Build(attribs);
                if (command.IsApplicable(registers))
                {
                    Register appliesTo = command.AppliesToRegister(registers);
                    command.Execute(appliesTo);
                }

                int currentLargestValue = registers.OrderByDescending(r => r.Value).First().Value;
                largestValue = currentLargestValue > largestValue ? currentLargestValue : largestValue;
            }
            file.Close();

            return largestValue;
        }
    }
}