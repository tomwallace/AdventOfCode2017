namespace AdventOfCode2017.TwentyTwo
{
    public class Node
    {
        private int _state; // 0 = Clean, 1 = Weakened, 2 = Infected, 3 = Flagged
        private bool _isResistant;

        public Node(char input, bool isResistant)
        {
            _isResistant = isResistant;
            if (input == '#')
                _state = 2;
            else
                _state = 0;
        }

        public int GetState()
        {
            return _state;
        }

        public bool IsInfected()
        {
            return _state == 2;
        }

        public void Interact()
        {
            if (_isResistant)
            {
                _state++;
                if (_state > 3)
                    _state = 0;
            }
            else
            {
                _state = _state == 2 ? 0 : 2;
            }
        }

        public override string ToString()
        {
            return _state.ToString();
        }
    }
}