using System;

namespace AdventOfCode2017.Three
{
    public class SpiralGrid
    {
        public long WidthStepsToCenter { get; set; }

        public long HeightStepsToCenter { get; set; }

        public long Width { get; set; }

        public long Height { get; set; }

        public long Length { get; set; }

        public SpiralGrid(long spiralSteps)
        {
            bool isHorizontal = true;
            long counter = 1;

            Width = 1;
            Height = 1;
            Length = spiralSteps;

            while (counter < spiralSteps)
            {
                if (isHorizontal)
                {
                    Width += 1;
                    counter += Width - 1;
                    if (counter > spiralSteps)
                    {
                        long centerPoint = counter - (Width/2);
                        WidthStepsToCenter = Math.Abs(spiralSteps - centerPoint);
                    }
                    else
                    {
                        WidthStepsToCenter = Width / 2;
                    }
                        
                }
                else
                {
                    Height += 1;
                    counter += Height - 1;
                    if (counter > spiralSteps)
                    {
                        long centerPoint = counter - (Height / 2);
                        HeightStepsToCenter = Math.Abs(spiralSteps - centerPoint);
                    }
                    else
                    {
                        HeightStepsToCenter = Height / 2;
                    }
                }

                isHorizontal = !isHorizontal;
            };
        }

        public long ManhattanDistance()
        {
            if (Length == 1)
                return 0;

            return WidthStepsToCenter + HeightStepsToCenter;
        }
    }
}