using System.Collections.Generic;

namespace AdventOfCode2017.Six
{
    public class MemoryModuleState
    {
        public List<int> State { get; }

        public MemoryModuleState(List<int> state)
        {
            State = state;
        }

        public override bool Equals(object obj)
        {
            MemoryModuleStateComparer comparer = new MemoryModuleStateComparer();
            return comparer.Equals(this, (MemoryModuleState)obj);
        }

        public override int GetHashCode()
        {
            MemoryModuleStateComparer comparer = new MemoryModuleStateComparer();
            return comparer.GetHashCode(this);
        }
    }
}