using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017.Three
{
    public class SpiralSummingGrid
    {
        private List<SpiralCell> _cells;
        private int _count;

        private int _maxHeight;
        private int _minHeight;
        private int _maxWidth;
        private int _minWidth;

        private Direction _direction;

        public SpiralSummingGrid()
        {
            _cells = new List<SpiralCell>();
            _cells.Add(new SpiralCell(1, 1, 1, false));
            _count = 1;
            _maxHeight = 1;
            _minHeight = 1;
            _maxWidth = 1;
            _minWidth = 1;
            _direction = new Direction();
        }

        public int AddCell()
        {
            if (_cells.Last().IsCorner)
                _direction.Change();

            int x = _cells.Last().XCoord + _direction.ModifyXCoord();
            int y = _cells.Last().YCoord + _direction.ModifyYCoord();
            bool isCorner = false;
            if (x > _maxWidth)
            {
                isCorner = true;
                _maxWidth++;
            }
            if (x < _minWidth)
            {
                isCorner = true;
                _minWidth--;
            }
            if (y > _maxHeight)
            {
                isCorner = true;
                _maxHeight++;
            }
            if (y < _minHeight)
            {
                isCorner = true;
                _minHeight--;
            }

            int value = FindValue(x, y);

            SpiralCell cell = new SpiralCell(x, y, value, isCorner);
            _cells.Add(cell);

            return value;
        }

        private int FindValue(int x, int y)
        {
            // Try to gather all surrounding cells, if they don't exist, then will add 0
            int south = _cells.Find(c => c.XCoord == x && c.YCoord == (y - 1))?.Value ?? 0;
            int southWest = _cells.Find(c => c.XCoord == (x - 1) && c.YCoord == (y - 1))?.Value ?? 0;
            int west = _cells.Find(c => c.XCoord == (x - 1) && c.YCoord == y)?.Value ?? 0;
            int northWest = _cells.Find(c => c.XCoord == (x - 1) && c.YCoord == (y + 1))?.Value ?? 0;
            int north = _cells.Find(c => c.XCoord == x && c.YCoord == (y + 1))?.Value ?? 0;
            int northEast = _cells.Find(c => c.XCoord == (x + 1) && c.YCoord == (y + 1))?.Value ?? 0;
            int east = _cells.Find(c => c.XCoord == (x + 1) && c.YCoord == y)?.Value ?? 0;
            int southEast = _cells.Find(c => c.XCoord == (x + 1) && c.YCoord == (y - 1))?.Value ?? 0;

            return south + southWest + west + northWest + north + northEast + east + southEast;
        }
    }
}