using System.Collections.Generic;

namespace AdventOfCode2017.Twenty
{
    public class ParticleComparer : IEqualityComparer<Particle>
    {
        public bool Equals(Particle p1, Particle p2)
        {
            if (p2 == null && p1 == null)
                return true;
            else if (p1 == null | p2 == null)
                return false;
            else if (p1.ToString().Equals(p2.ToString()))
                return true;
            else
                return false;
        }

        public int GetHashCode(Particle p)
        {
            return p.ToString().GetHashCode();
        }
    }
}