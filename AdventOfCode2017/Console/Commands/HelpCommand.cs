namespace AdventOfCode2017.Console.Commands
{
    public class HelpCommand : ICommand
    {
        public void Execute()
        {
            System.Console.WriteLine("AdventOfCode2017 offers the following commands");
            System.Console.WriteLine("");

            System.Console.WriteLine("/clear");
            System.Console.WriteLine("/c");
            System.Console.WriteLine("Clears the current console window.");
            System.Console.WriteLine("");

            System.Console.WriteLine("/help");
            System.Console.WriteLine("/h");
            System.Console.WriteLine("Displays the help menu.");
            System.Console.WriteLine("");

            System.Console.WriteLine("/list");
            System.Console.WriteLine("/l");
            System.Console.WriteLine("Lists the number of Days of puzzles in the project, along with their descriptions.");
            System.Console.WriteLine("");

            System.Console.WriteLine("/run");
            System.Console.WriteLine("/r");
            System.Console.WriteLine("Runs a problem.  Use like - /run DayOne PartA");
            System.Console.WriteLine("");

            System.Console.WriteLine("/quit");
            System.Console.WriteLine("/q");
            System.Console.WriteLine("Exits the program.");
            System.Console.WriteLine("");

            System.Console.WriteLine("/version");
            System.Console.WriteLine("/v");
            System.Console.WriteLine("Lists the version of the program.");
            System.Console.WriteLine("");

            // TODO: Remove excess
            /*
            Console.WriteLine("/retrieve [x]");
            Console.WriteLine("/r [x]");
            Console.WriteLine("Retrieves x number of messages to the MSMQ server and provides the time it takes to do so.");
            Console.WriteLine("If x is not provided, then retrieves one message.");
            Console.WriteLine("");

            Console.WriteLine("/settings");
            Console.WriteLine("Lists the current settings and their values.");
            Console.WriteLine("");

            Console.WriteLine("/settings length [x]");
            Console.WriteLine("Sets the message length to x, where x is a number between 10 and integer max.");
            Console.WriteLine("");

            Console.WriteLine("/settings persist [x]");
            Console.WriteLine("Sets the persistance level to x, where x is true or false.");
            Console.WriteLine("");
            */
        }

        public bool HadErrorInCreation()
        {
            return false;
        }
    }
}