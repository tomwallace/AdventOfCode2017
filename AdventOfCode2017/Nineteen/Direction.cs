using System.Collections.Generic;

namespace AdventOfCode2017.Nineteen
{
    public class Direction
    {
        private int _currentDirection; // 1 = right, 2 = up, 3 = left, 4 = down

        public bool IsTerminated { get; set; }

        public Direction(int currentDirection)
        {
            _currentDirection = currentDirection;
            IsTerminated = false;
        }

        public int ModifyXCoord()
        {
            switch (_currentDirection)
            {
                case 1:
                    return -1;
                case 3:
                    return 1;
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

        public void ChangeDirection(int x, int y, List<List<char>> map)
        {
            char n = ' ';
            if (y - 1 >= 0)
                n = map[y-1][x];

            char e = ' ';
            if (x + 1 < map[y].Count)
                e = map[y][x+1];

            char s = ' ';
            if (y + 1 < map.Count)
                s = map[y+1][x];

            char w = ' ';
            if (x - 1 >= 0)
                w = map[y][x - 1];

            switch (_currentDirection)
            {
                case 1:
                    if (n != ' ')
                        _currentDirection = 2;
                    else if (s != ' ')
                        _currentDirection = 4;
                    else
                        IsTerminated = true;
                    break;
                case 2:
                    if (w != ' ')
                        _currentDirection = 1;
                    else if (e != ' ')
                        _currentDirection = 3;
                    else
                        IsTerminated = true;
                    break;
                case 3:
                    if (n != ' ')
                        _currentDirection = 2;
                    else if (s != ' ')
                        _currentDirection = 4;
                    else
                        IsTerminated = true;
                    break;
                case 4:
                    if (w != ' ')
                        _currentDirection = 1;
                    else if (e != ' ')
                        _currentDirection = 3;
                    else
                        IsTerminated = true;
                    break;
            }
        }
    }
}