namespace AdventOfCode2017.Three
{
    public class Direction
    {
        private int _currentDirection; // 1 = right, 2 = up, 3 = left, 4 = down

        public Direction()
        {
            _currentDirection = 1;  // start going right
        }

        public void Change()
        {
            _currentDirection++;
            if (_currentDirection > 4)
                _currentDirection = 1;
        }

        public int ModifyXCoord()
        {
            switch (_currentDirection)
            {
                case 1:
                    return 1;
                case 3:
                    return -1;
                default:
                    return 0;
            }
        }

        public int ModifyYCoord()
        {
            switch (_currentDirection)
            {
                case 2:
                    return 1;
                case 4:
                    return -1;
                default:
                    return 0;
            }
        }
    }
}