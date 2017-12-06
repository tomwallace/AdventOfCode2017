using AdventOfCode2017.Console;

namespace AdventOfCode2017
{
    public class Program
    {

        private static readonly string LINE_PREFIX = "AoC2017:> ";

        static void Main(string[] args)
        {
            while (true)
            {
                System.Console.Write(LINE_PREFIX);
                string commandLine = System.Console.ReadLine();

                CommandBuilder builder = new CommandBuilder();
                ICommand command = builder.Build(commandLine);

                if (!command.HadErrorInCreation())
                {
                    command.Execute();
                }
            }
        }
    }
}