using System.Diagnostics;

namespace AdventOfCode2017.Seventeen
{
    public class DaySeventeen : IAdventProblemSet
    {
        public static int Input = 348;

        public string Description()
        {
            return "Spinlock";
        }

        public int SortOrder()
        {
            return 17;
        }

        public string PartA()
        {
            return IterateSpinLock(Input).ToString();
        }

        public string PartB()
        {
            SpinLockSingleIndex spinLockSingleIndex = new SpinLockSingleIndex(Input, 1);
            return spinLockSingleIndex.Calculate(50000000).ToString();
        }

        public int IterateSpinLock(int stepsPerIteration)
        {
            SpinLock spinLock = new SpinLock(stepsPerIteration);
            int currentNextValue = 0;
            for (int i = 1; i <= 2017; i++)
            {
                currentNextValue = spinLock.IterateAndValueOfNextIndex(i);
            }

            return currentNextValue;
        }
    }
}