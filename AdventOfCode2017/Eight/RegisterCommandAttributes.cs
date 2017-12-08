using System;

namespace AdventOfCode2017.Eight
{
    public class RegisterCommandAttributes
    {
        public string RegisterName { get; set; }

        public string CommandName { get; set; }

        public int Modifier { get; set; }

        public string ConditionName { get; set; }

        public string ConditionEvaluator { get; set; }

        public int ConditionTest { get; set; }

        public RegisterCommandAttributes(string command)
        {
            string[] commandSplit = command.Split(' ');

            RegisterName = commandSplit[0];
            CommandName = commandSplit[1];
            Modifier = Int32.Parse(commandSplit[2]);

            string[] commandSplitIf = command.Split(new string[] { " if " }, StringSplitOptions.None);
            string condition = commandSplitIf[1];

            string[] splitCondition = condition.Split(' ');
            ConditionName = splitCondition[0];
            ConditionEvaluator = splitCondition[1];
            ConditionTest = Int32.Parse(splitCondition[2]);
        }
    }
}