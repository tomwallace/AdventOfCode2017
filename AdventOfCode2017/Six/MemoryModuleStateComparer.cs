using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017.Six
{
    public class MemoryModuleStateComparer : IEqualityComparer<MemoryModuleState>
    {
        public bool Equals(MemoryModuleState m1, MemoryModuleState m2)
        {
            if (m2 == null && m1 == null)
                return true;
            else if (m1 == null | m2 == null)
                return false;
            else if (m1.State.SequenceEqual(m2.State))
                return true;
            else
                return false;
        }

        public int GetHashCode(MemoryModuleState m)
        {
            int hCode = 0;
            foreach (int value in m.State)
            {
                hCode = hCode ^ value;
            }
            return hCode.GetHashCode();
        }
    }
}