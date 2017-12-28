namespace AdventOfCode2017.TwentyFive
{
    public class TuringState
    {
        private readonly bool _writeWhenTrue;
        private readonly bool _writeWhenFalse;
        private readonly int _moveWhenTrue;
        private readonly int _moveWhenFalse;
        private readonly string _nextKeyWhenTrue;
        private readonly string _nextKeyWhenFalse;

        public TuringState(bool writeWhenTrue, bool writeWhenFalse, int moveWhenTrue, int moveWhenFalse,
            string nextKeyWhenTrue, string nextKeyWhenFalse)
        {
            _writeWhenTrue = writeWhenTrue;
            _writeWhenFalse = writeWhenFalse;
            _moveWhenTrue = moveWhenTrue;
            _moveWhenFalse = moveWhenFalse;
            _nextKeyWhenTrue = nextKeyWhenTrue;
            _nextKeyWhenFalse = nextKeyWhenFalse;
        }

        public bool Write(bool currentValue)
        {
            if (currentValue)
                return _writeWhenTrue;

            return _writeWhenFalse;
        }

        public int Move(bool currentValue)
        {
            if (currentValue)
                return _moveWhenTrue;

            return _moveWhenFalse;
        }

        public string NextStateKey(bool currentValue)
        {
            if (currentValue)
                return _nextKeyWhenTrue;

            return _nextKeyWhenFalse;
        }
    }
}