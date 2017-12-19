using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2017.Eighteen
{
    public class DayEighteen : IAdventProblemSet
    {
        private SoundBoard _zero;
        private SoundBoard _one;

        public string Description()
        {
            return "Duet";
        }

        public int SortOrder()
        {
            return 18;
        }

        public string PartA()
        {
            string filePath = @"Eighteen\DayEighteenInput.txt";
            return RunThroughInstructions(filePath);
        }

        public string PartB()
        {
            string filePath = @"Eighteen\DayEighteenInput.txt";
            return DuetInstructions(filePath);
        }

        public string RunThroughInstructions(string filePath)
        {
            List<string> instructions = GetInstructions(filePath);

            _one = new SoundBoard();
            string received = null;
            do
            {
                string instruction = instructions[_one.CurrentInstruction];
                received = ProcessInstruction(instruction, _one, false);
                _one.CurrentInstruction++;
            } while (received == null);

            return received;
        }

        public string DuetInstructions(string filePath)
        {
            List<string> instructions = GetInstructions(filePath);

            _zero = new SoundBoard();
            _zero.Id = 0;
            _zero.Registers.Add("p", 0);

            _one = new SoundBoard();
            _one.Id = 1;
            _one.Registers.Add("p", 1);

            do
            {
                string instructionZero = instructions[_zero.CurrentInstruction];
                ProcessInstruction(instructionZero, _zero, true);
                if (!_zero.Paused)
                    _zero.CurrentInstruction++;

                string instructionOne = instructions[_one.CurrentInstruction];
                ProcessInstruction(instructionOne, _one, true);
                if (!_one.Paused)
                    _one.CurrentInstruction++;
            } while (!_zero.Paused || !_one.Paused);

            return _one.TimesSentInstructions.ToString();
        }

        public string ProcessInstruction(string command, SoundBoard soundBoard, bool isPartB)
        {
            string[] commandSplit = command.Split(' ');
            switch (commandSplit[0])
            {
                case "snd":
                    soundBoard.LastPlayed = DetermineValue(commandSplit[1], soundBoard);
                    if (isPartB)
                    {
                        soundBoard.TimesSentInstructions++;
                        if (soundBoard.Id == 0)
                            _one.MessagesSentFromOther.Enqueue(soundBoard.LastPlayed);
                        else
                            _zero.MessagesSentFromOther.Enqueue(soundBoard.LastPlayed);
                    }
                    break;

                case "set":
                    DetermineValue(commandSplit[1], soundBoard);
                    soundBoard.Registers[commandSplit[1]] = DetermineValue(commandSplit[2], soundBoard);
                    break;

                case "add":
                    DetermineValue(commandSplit[1], soundBoard);
                    soundBoard.Registers[commandSplit[1]] += DetermineValue(commandSplit[2], soundBoard);
                    break;

                case "mul":
                    DetermineValue(commandSplit[1], soundBoard);
                    soundBoard.Registers[commandSplit[1]] = soundBoard.Registers[commandSplit[1]] * DetermineValue(commandSplit[2], soundBoard);
                    break;

                case "mod":
                    DetermineValue(commandSplit[1], soundBoard);
                    soundBoard.Registers[commandSplit[1]] = soundBoard.Registers[commandSplit[1]] % DetermineValue(commandSplit[2], soundBoard);
                    break;

                case "rcv":
                    if (!isPartB)
                    {
                        if (soundBoard.Registers[commandSplit[1]] > 0)
                            return soundBoard.LastPlayed.ToString();
                    }
                    else
                    {
                        if (soundBoard.MessagesSentFromOther.Count > 0)
                        {
                            DetermineValue(commandSplit[1], soundBoard);
                            soundBoard.Registers[commandSplit[1]] = soundBoard.MessagesSentFromOther.Dequeue();
                            soundBoard.Paused = false;
                        }
                        else
                        {
                            soundBoard.Paused = true;
                        }
                    }

                    break;

                case "jgz":
                    long firstValue = DetermineValue(commandSplit[1], soundBoard);
                    if (firstValue > 0)
                        soundBoard.CurrentInstruction += (int)DetermineValue(commandSplit[2], soundBoard) - 1;
                    break;

                default:
                    throw new ArgumentException("Unknown command");
            }

            return null;
        }

        private long DetermineValue(string value, SoundBoard soundBoard)
        {
            long result;
            if (long.TryParse(value, out result))
                return result;

            long found = FindRegisterValueOrCreateNew(value, soundBoard);
            return found;
        }

        private long FindRegisterValueOrCreateNew(string key, SoundBoard soundBoard)
        {
            if (soundBoard.Registers.ContainsKey(key))
                return soundBoard.Registers[key];

            soundBoard.Registers.Add(key, 0);
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