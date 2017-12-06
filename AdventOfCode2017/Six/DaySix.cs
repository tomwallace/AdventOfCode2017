namespace AdventOfCode2017.Six
{
    public class DaySix : IAdventProblemSet
    {
        public static readonly int[] Input = new[] { 2, 8, 8, 5, 4, 2, 3, 1, 5, 5, 1, 2, 15, 13, 5, 14 };

        public string Description()
        {
            return "Memory Reallocation";
        }

        public int SortOrder()
        {
            return 6;
        }

        public string PartA()
        {
            return NumberOfStepsUntilDuplicateState(Input).ToString();
        }

        public string PartB()
        {
            return NumberOfStepsBetweenFirstDuplicate(Input).ToString();
        }

        public int NumberOfStepsUntilDuplicateState(int[] initialBlocks)
        {
            MemoryModule memoryModule = new MemoryModule(initialBlocks);
            int steps = 0;

            bool noDuplicateState = true;

            while (noDuplicateState)
            {
                steps++;
                memoryModule.Reallocate();
                noDuplicateState = memoryModule.NoDuplicateState();
            }

            return steps;
        }

        public int NumberOfStepsBetweenFirstDuplicate(int[] initialBlocks)
        {
            MemoryModule memoryModule = new MemoryModule(initialBlocks);
            int steps = 0;

            bool noDuplicateState = true;

            while (noDuplicateState)
            {
                steps++;
                memoryModule.Reallocate();
                noDuplicateState = memoryModule.NoDuplicateState();
            }

            int stepOfFirstDuplicate = memoryModule.IndexOfFirstDuplicate();
            return steps - (stepOfFirstDuplicate + 1);
        }
    }
}