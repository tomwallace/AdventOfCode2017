using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017.TwentyOne
{
    public class PixelProgram
    {
        private readonly List<List<char>> _pixels;

        public PixelProgram(string input)
        {
            _pixels = new List<List<char>>();
            string[] inputSplit = input.Split('/');
            foreach (string line in inputSplit)
            {
                _pixels.Add(line.Trim().ToCharArray().ToList());
            }
        }

        public int Size()
        {
            return _pixels.Count;
        }

        public override string ToString()
        {
            string output = "";
            foreach (List<char> line in _pixels)
            {
                output += new string(line.ToArray()) + "/";
            }
            return output.Substring(0, (output.Length - 1));
        }

        public int PixelsTurnedOn()
        {
            string pixelsString = ToString();
            int output = pixelsString.ToCharArray().Where(p => p == '#').Count();
            return output;
        }

        public List<string> AllRotationsAndFlips()
        {
            List<string> output = new List<string>();
            string rotated = ToString();
            output.Add(rotated);
            rotated = RotateTransform(rotated);
            output.Add(rotated);
            string flipped = FlipTransform(rotated);
            output.Add(flipped);
            rotated = RotateTransform(rotated);
            output.Add(rotated);
            flipped = FlipTransform(rotated);
            output.Add(flipped);
            rotated = RotateTransform(rotated);
            output.Add(rotated);
            flipped = FlipTransform(rotated);
            output.Add(flipped);
            rotated = RotateTransform(rotated);
            output.Add(rotated);
            flipped = FlipTransform(rotated);
            output.Add(flipped);

            return output;
        }

        public List<List<PixelProgram>> Split()
        {
            List<List<PixelProgram>> output = new List<List<PixelProgram>>();
            int size = Size();

            if ((size % 2) == 0)
            {
                for (int y = 0; y < size; y += 2)
                {
                    List<PixelProgram> localList = new List<PixelProgram>();
                    for (int x = 0; x < size; x += 2)
                    {
                        string program = $"{_pixels[y][x]}{_pixels[y][x + 1]}/{_pixels[y + 1][x]}{_pixels[y + 1][x + 1]}";
                        localList.Add(new PixelProgram(program));
                    }
                    output.Add(localList);
                }
            }
            else if ((size % 3) == 0)
            {
                for (int y = 0; y < size; y += 3)
                {
                    List<PixelProgram> localList = new List<PixelProgram>();
                    for (int x = 0; x < size; x += 3)
                    {
                        string program =
                            $"{_pixels[y][x]}{_pixels[y][x + 1]}{_pixels[y][x + 2]}/{_pixels[y + 1][x]}{_pixels[y + 1][x + 1]}{_pixels[y + 1][x + 2]}/{_pixels[y + 2][x]}{_pixels[y + 2][x + 1]}{_pixels[y + 2][x + 2]}";
                        localList.Add(new PixelProgram(program));
                    }
                    output.Add(localList);
                }
            }
            else
            {
                throw new ArgumentException("Not divisible by either 2 or 3");
            }

            return output;
        }

        private string RotateTransform(string input)
        {
            List<List<char>> pixels = new List<List<char>>();
            string[] inputSplit = input.Split('/');
            foreach (string line in inputSplit)
            {
                pixels.Add(line.Trim().ToCharArray().ToList());
            }

            string rotated = "";
            int size = pixels.Count;
            for (int x = 0; x < size; x++)
            {
                string line = "";
                for (int y = (size - 1); y >= 0; y--)
                {
                    line += pixels[y][x];
                }
                rotated += line + "/";
            }

            return rotated.Substring(0, rotated.Length - 1);
        }

        private string FlipTransform(string input)
        {
            List<List<char>> pixels = new List<List<char>>();
            string[] inputSplit = input.Split('/');
            foreach (string line in inputSplit)
            {
                pixels.Add(line.Trim().ToCharArray().ToList());
            }

            // 2,0; 2,1; 2,2; 1,0; 1,1; 1,2; 0,0; 0,1; 0,2
            int size = pixels.Count;
            string flipped = "";
            for (int y = (size - 1); y >= 0; y--)
            {
                string line = "";
                for (int x = 0; x < size; x++)
                {
                    line += pixels[y][x];
                }
                flipped += line + "/";
            }

            return flipped.Substring(0, flipped.Length - 1);
        }
    }
}