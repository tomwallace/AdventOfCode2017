namespace AdventOfCode2017.Seventeen
{
    public class SpinLockSingleIndex
    {
        private int _length;
        private readonly int _targetedIndex;
        private int _currentIndex;
        private readonly int _stepsPerIteration;
        private int _lastValue;

        public SpinLockSingleIndex(int stepsPerIteration, int targetedIndex)
        {
            _length = 0;
            _targetedIndex = targetedIndex;
            _currentIndex = 0;
            _stepsPerIteration = stepsPerIteration;
            _lastValue = 0;
        }

        public int Calculate(int numberOfSteps)
        {
            for (int i = 1; i <= numberOfSteps; i++)
            {
                _length = i;
                int insertionIndex = DetermineIndex();
                _currentIndex = insertionIndex + 1;

                if (_currentIndex == _targetedIndex)
                    _lastValue = i;
            }

            return _lastValue;
        }

        private int DetermineIndex()
        {
            int stepsFromStart = _stepsPerIteration % _length;
            if ((stepsFromStart + _currentIndex) >= _length)
                return (stepsFromStart + _currentIndex) - _length;

            return stepsFromStart + _currentIndex;
        }
    }
}