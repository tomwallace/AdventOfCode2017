using System;

namespace AdventOfCode2017.Fifteen
{
    public class Generator
    {
        private readonly int _multiplyingFactor;
        private long _currentValue;
        private string _currentBinary;
        private readonly int _multipleForJudge;

        private int _divider = 2147483647;

        public Generator(long startingValue, int multiplyingFactor, int multipleForJudge)
        {
            _currentValue = startingValue;
            _multiplyingFactor = multiplyingFactor;
            _multipleForJudge = multipleForJudge;
            GenerateBinary();
        }

        public long NextValue()
        {
            long nextValue = (_currentValue * _multiplyingFactor) % _divider;
            _currentValue = nextValue;

            GenerateBinary();

            return nextValue;
        }

        public string CurrentBinary()
        {
            if (_currentValue % _multipleForJudge == 0)
                return _currentBinary;

            return null;
        }

        public bool IsEqual(Generator other)
        {
            string myRightSixteen = _currentBinary.Substring(16);
            string otherRightSixteen = other.CurrentBinary().Substring(16);
            return myRightSixteen == otherRightSixteen;
        }

        private void GenerateBinary()
        {
            string binaryString = Convert.ToString(_currentValue, 2).PadLeft(32, '0');
            _currentBinary = binaryString;
        }
    }
}