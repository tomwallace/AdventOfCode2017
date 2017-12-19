using System.Collections.Generic;

namespace AdventOfCode2017.Eighteen
{
    public class SoundBoard
    {
        public int Id { get; set; }

        public Queue<long> MessagesSentFromOther { get; set; }

        public bool Paused { get; set; }

        public int TimesSentInstructions { get; set; }

        public int CurrentInstruction { get; set; }

        public long LastPlayed { get; set; }

        public Dictionary<string, long> Registers { get; set; }

        public SoundBoard()
        {
            Registers = new Dictionary<string, long>();
            LastPlayed = 0;
            CurrentInstruction = 0;
            MessagesSentFromOther = new Queue<long>();
            TimesSentInstructions = 0;
            Paused = false;
        }
    }
}