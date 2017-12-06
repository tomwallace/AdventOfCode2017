using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017.Six
{
    public class MemoryModule
    {
        private List<MemoryModuleState> _states;
        private List<MemoryBank> _memoryBanks;

        public MemoryModule(int[] initialBlocks)
        {
            _states = new List<MemoryModuleState>();
            _memoryBanks = new List<MemoryBank>();

            MemoryBank firstBank = new MemoryBank();
            firstBank.Blocks = initialBlocks[0];
            firstBank.Id = 1;
            _memoryBanks.Add(firstBank);

            MemoryBank previousPointer = firstBank;
            for(int x = 2; x <= initialBlocks.Length; x++)
            {
                MemoryBank bank = new MemoryBank();
                bank.Blocks = initialBlocks[x - 1];
                bank.Id = x;
                // Chain together
                previousPointer.Next = bank;
                previousPointer = bank;

                _memoryBanks.Add(bank);
            }
            // Handle the last one - now should be a linked circle
            previousPointer.Next = firstBank;
        }

        public void Reallocate()
        {
            MemoryBank largest = _memoryBanks.OrderByDescending(b => b.Blocks).First();
            int blocksToSpread = largest.Blocks;
            largest.Blocks = 0;

            MemoryBank current = largest;
            for (int x = blocksToSpread; x > 0; x--)
            {
                current = current.Next;
                current.Blocks++;
            }

            // Save off current state
            MemoryModuleState currentState = new MemoryModuleState(_memoryBanks.Select(x => x.Blocks).ToList());
            _states.Add(currentState);
        }

        public bool NoDuplicateState()
        {
            return _states.Count == _states.Distinct().ToList().Count;
        }

        public int IndexOfFirstDuplicate()
        {
            MemoryModuleState last = _states.Last();
            int index = _states.FindIndex(s => s.Equals(last));

            return index;
        }

    }
}