using AdventOfCode2017.Eight.RegisterCommands;
using System;

namespace AdventOfCode2017.Eight
{
    public class RegisterCommandBuilder
    {
        public IRegisterCommand Build(RegisterCommandAttributes attribs)
        {
            IRegisterCommand createdCommand;

            switch (attribs.CommandName)
            {
                case "inc":
                    createdCommand = new IncreaseRegisterCommand(attribs);
                    break;

                case "dec":
                    createdCommand = new DecreaseRegisterCommand(attribs);
                    break;

                default:
                    throw new ArgumentException("Command requested not defined");
            }

            return createdCommand;
        }
    }
}