namespace AdventOfCode2017.TwentyTwo
{
    public class Direction
    {
        private int _currentDirection; // 1 = right, 2 = up, 3 = left, 4 = down

        public Direction(int currentDirection)
        {
            _currentDirection = currentDirection;
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
                    return -1;

                case 4:
                    return 1;

                default:
                    return 0;
            }
        }

        public void ChangeDirection(int nodeState)
        {
            switch (_currentDirection)
            {
                case 1:
                    if (nodeState == 2)
                        _currentDirection = 4;
                    else if (nodeState == 0)
                        _currentDirection = 2;
                    else if (nodeState == 3)
                        _currentDirection = 3;
                    break;

                case 2:
                    if (nodeState == 2)
                        _currentDirection = 1;
                    else if (nodeState == 0)
                        _currentDirection = 3;
                    else if (nodeState == 3)
                        _currentDirection = 4;
                    break;

                case 3:
                    if (nodeState == 2)
                        _currentDirection = 2;
                    else if (nodeState == 0)
                        _currentDirection = 4;
                    else if (nodeState == 3)
                        _currentDirection = 1;
                    break;

                case 4:
                    if (nodeState == 2)
                        _currentDirection = 3;
                    else if (nodeState == 0)
                        _currentDirection = 1;
                    else if (nodeState == 3)
                        _currentDirection = 2;
                    break;
            }
        }
    }
}