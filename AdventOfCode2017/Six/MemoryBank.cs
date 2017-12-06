namespace AdventOfCode2017.Six
{
    public class MemoryBank
    {
        public int Id { get; set; }

        public int Blocks { get; set; }

        public MemoryBank Next { get; set; }
    }
}