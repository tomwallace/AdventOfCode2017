using System;

namespace AdventOfCode2017.Console.Commands
{
    public class QuitCommand : ICommand
    {
        public void Execute()
        {
            Environment.Exit(0);
        }

        public bool HadErrorInCreation()
        {
            return false;
        }
    }
}