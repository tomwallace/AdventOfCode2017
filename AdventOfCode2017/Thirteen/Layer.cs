using System;

namespace AdventOfCode2017.Thirteen
{
    public class Layer
    {
        private int _scannerLocation;
        private bool _goingDown;
        private bool _isSecured;

        public int Id { get; }

        public int Range { get; }

        public Layer(string input)
        {
            // ex: 0: 3
            string[] inputSplit = input.Split(':');
            Id = Int32.Parse(inputSplit[0].Trim());
            Range = Int32.Parse(inputSplit[1].Trim());

            _scannerLocation = 0;
            _goingDown = true;
            _isSecured = true;
        }

        public Layer(int emptyId)
        {
            Id = emptyId;
            _isSecured = false;
        }

        public override string ToString()
        {
            return $"Layer: isSecured: {_isSecured} scannerLoc: {_scannerLocation}";
        }

        public bool IsCaught()
        {
            if (!_isSecured)
                return false;

            return _scannerLocation == 0;
        }

        public void Advance()
        {
            if (_isSecured)
            {
                int modifier = _goingDown ? 1 : -1;
                if ((_scannerLocation + modifier) >= Range || (_scannerLocation + modifier) < 0)
                {
                    _goingDown = !_goingDown;
                    modifier = _goingDown ? 1 : -1;
                }

                _scannerLocation += modifier;
            }
        }

        public int Severity()
        {
            return Id * Range;
        }
    }
}