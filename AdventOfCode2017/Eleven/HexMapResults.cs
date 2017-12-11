namespace AdventOfCode2017.Eleven
{
    public class HexMapResults
    {
        public int EndSteps { get; }

        public int MaxStepsAway { get; }

        public HexMapResults(int endSteps, int maxStepsAway)
        {
            EndSteps = endSteps;
            MaxStepsAway = maxStepsAway;
        }
    }
}