using AdventOfCode2017.Ten;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2017.Fourteen
{
    public class DayFourteen : IAdventProblemSet
    {
        public static string Input = "amgozmfv";

        public string Description()
        {
            return "Disk Defragmentation";
        }

        public int SortOrder()
        {
            return 14;
        }

        public string PartA()
        {
            return CalculateNumberOfUsedSquares(Input).ToString();
        }

        public string PartB()
        {
            return CalculateNumberOfRegions(Input).ToString();
        }
        
        public int CalculateNumberOfUsedSquares(string baseInput)
        {
            int usedSquares = 0;
            for (int i = 0; i < 128; i++)
            {
                string input = $"{baseInput}-{i}";
                string row = CreateFragmenterRow(input);
                int localUsedSquares = row.ToCharArray().Where(c => c == '1').Count();
                usedSquares += localUsedSquares;
            }

            return usedSquares;
        }

        public int CalculateNumberOfRegions(string baseInput)
        {
            List<string> diskInput = new List<string>();
            for (int i = 0; i < 128; i++)
            {
                string input = $"{baseInput}-{i}";
                string row = CreateFragmenterRow(input);
                diskInput.Add(row);
            }

            Disk disk = new Disk(diskInput);
            int result = disk.CountRegions();
            return result;
        }

        public string CreateFragmenterRow(string localInput)
        {
            KnotHash knotHash = new KnotHash(localInput);

            return ConvertHexToBinaryString(knotHash.HexOutput);
        }

        
        public string ConvertHexToBinaryString(string input)
        {
            string binarystring = string.Join(string.Empty,
                                      input.Select(
                                        c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')
                                      )
                                    );
            return binarystring;
        }
    }

    public class Disk
    {
        private List<Location> _locations;

        public Disk(List<string> rows)
        {
            _locations = new List<Location>();

            int rowCounter = 0;
            int cCounter = 0;
            foreach (string row in rows)
            {
                foreach (char c in row)
                {
                    bool isUsed = c == '1';
                    Location location = new Location() { Id = $"{rowCounter}.{cCounter}", IsUsed = isUsed, IsRemoved = false};
                    _locations.Add(location);
                    cCounter++;
                }
                cCounter = 0;
                rowCounter++;
            }

            LinkLocations();
        }

        public int CountRegions()
        {
            int regions = 0;
            for (int row = 0; row < 128; row++)
            {
                for (int col = 0; col < 128; col++)
                {
                    Location current = _locations.Find(l => l.Id == $"{row}.{col}");
                    if (current.IsAvailable())
                    {
                        regions++;
                        MarkRegion(current);
                    }
                }
            }

            return regions;
        }

        private void MarkRegion(Location start)
        {
            Queue<Location> queue = new Queue<Location>();
            queue.Enqueue(start);

            do
            {
                Location current = queue.Dequeue();

                if (current.IsAvailable())
                {
                    current.IsRemoved = true;
                    if (current.North != null && current.North.IsAvailable())
                        queue.Enqueue(current.North);

                    if (current.East != null && current.East.IsAvailable())
                        queue.Enqueue(current.East);

                    if (current.West != null && current.West.IsAvailable())
                        queue.Enqueue(current.West);

                    if (current.South != null && current.South.IsAvailable())
                        queue.Enqueue(current.South);
                }

            } while (queue.Count > 0);
        }

        private void LinkLocations()
        {
            for (int row = 0; row < 128; row++)
            {
                for (int col = 0; col < 128; col++)
                {
                    Location current = _locations.Find(l => l.Id == $"{row}.{col}");
                    Location north = _locations.FirstOrDefault(l => l.Id == $"{row+1}.{col}");
                    Location east = _locations.FirstOrDefault(l => l.Id == $"{row}.{col+1}");
                    Location south = _locations.FirstOrDefault(l => l.Id == $"{row-1}.{col}");
                    Location west = _locations.FirstOrDefault(l => l.Id == $"{row}.{col-1}");
                    current.North = north;
                    if (current.North != null)
                        current.North.South = current;
                    current.East = east;
                    if (current.East != null)
                        current.East.West = current;
                    current.South = south;
                    if (current.South != null)
                        current.South.North = current;
                    current.West = west;
                    if (current.West != null)
                        current.West.East = current;
                }
            }
        }
    }

    public class Location
    {
        public string Id { get; set; }

        public bool IsUsed { get; set; }

        public bool IsRemoved { get; set; }

        public Location North { get; set; }

        public Location East { get; set; }

        public Location South { get; set; }

        public Location West { get; set; }

        public bool IsAvailable()
        {
            return IsUsed && !IsRemoved;
        }
    }
}