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
            return "";
        }
        
        public int CalculateNumberOfUsedSquares(string baseInput)
        {
            // TODO: consider removing disk, as not really used
            List<string> disk = new List<string>();
            int usedSquares = 0;
            for (int i = 0; i < 128; i++)
            {
                string input = $"{baseInput}-{i}";
                string row = CreateFragmenterRow(input);
                int localUsedSquares = row.ToCharArray().Where(c => c == '1').Count();
                usedSquares += localUsedSquares;
                disk.Add(row);
            }

            return usedSquares;
        }

        public string CreateFragmenterRow(string localInput)
        {
            // ex: flqrgnkx-0
            // TODO: Refactor into a utility class that is not tied directly to a puzzle
            DayTen dayTen = new DayTen();

            List<int> knotHashInput = dayTen.ToAsciiCode(localInput);
            string knotHash = dayTen.ToKnotHash(knotHashInput);

            return ConvertHexToBinaryString(knotHash);
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
        /*
        public byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
        */
    }
}