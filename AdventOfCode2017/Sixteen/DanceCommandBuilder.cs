using System;

namespace AdventOfCode2017.Sixteen
{
    public class DanceCommandBuilder
    {
        public IDanceCommand Build(string command)
        {
            IDanceCommand createdCommand;

            string firstChar = command.Substring(0, 1);
            switch (firstChar)
            {
                case "s":
                    createdCommand = new Spin(command);
                    break;

                case "x":
                    createdCommand = new Exchange(command);
                    break;

                case "p":
                    createdCommand = new Partner(command);
                    break;

                default:
                    throw new ArgumentException("Command requested not defined");
            }

            return createdCommand;
        }
    }
}