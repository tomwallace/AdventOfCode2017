namespace AdventOfCode2017.Nine
{
    public class ParseResults
    {
        public int TotalScore { get; set; }

        public int GarbageScore { get; set; }

        public ParseResults(int totalScore, int garbageScore)
        {
            TotalScore = totalScore;
            GarbageScore = garbageScore;
        }
    }
}