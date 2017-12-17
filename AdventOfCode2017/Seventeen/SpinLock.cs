using System.Collections.Generic;

namespace AdventOfCode2017.Seventeen
{
    public class SpinLock
    {
        private readonly List<int> _buffer;
        private int _currentIndex;
        private readonly int _stepsPerIteration;

        public SpinLock(int stepsPerIteration)
        {
            _buffer = new List<int>();
            _buffer.Add(0);
            _currentIndex = 0;
            _stepsPerIteration = stepsPerIteration;
        }

        public int IterateAndValueOfNextIndex(int iteration)
        {
            int insertionIndex = DetermineIndex();
            _buffer.Insert(insertionIndex + 1, iteration);
            _currentIndex = insertionIndex + 1;

            int nextIndex = _currentIndex + 1;
            if (nextIndex >= _buffer.Count)
                nextIndex = nextIndex - _buffer.Count;

            return _buffer[nextIndex];
        }

        public override string ToString()
        {
            string output = "";
            foreach (int iteration in _buffer)
            {
                output = $"{output}{iteration}";
            }
            return output;
        }

        private int DetermineIndex()
        {
            int length = _buffer.Count;
            int stepsFromStart = _stepsPerIteration%length;
            if ((stepsFromStart + _currentIndex) >= length)
                return (stepsFromStart + _currentIndex) - length;

            return stepsFromStart + _currentIndex;
        }
    }
}