using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2017.TwentyOne
{
    public class DayTwentyOne : IAdventProblemSet
    {
        public static string Start = ".#./..#/###";

        public string Description()
        {
            return "Fractal Art (VERY HARD)";
        }

        public int SortOrder()
        {
            return 21;
        }

        // TODO: Clean up unused code
        public string PartA()
        {
            string filePath = @"TwentyOne\DayTwentyOneInput.txt";
            return TransformArtAndCountPizelsTurnedOn(filePath, 5).ToString();
        }

        public string PartB()
        {
            string filePath = @"TwentyOne\DayTwentyOneInput.txt";
            return TransformArtAndCountPizelsTurnedOn(filePath, 18).ToString();
        }

        public int TransformArtAndCountPizelsTurnedOn(string filePath, int iterations)
        {
            Dictionary<string, string> rules = CreateRules(filePath);

            PixelProgram pixelProgram = new PixelProgram(Start);
            int counter = 0;

            do
            {
                pixelProgram = ExplodePixelProgram(pixelProgram, rules);

                counter++;
            } while (counter < iterations);

            return pixelProgram.PixelsTurnedOn();
        }

        public PixelProgram ExplodePixelProgram(PixelProgram current, Dictionary<string, string> rules)
        {
            List<string> explodedProgramInput = new List<string>();
            int totalNumRows = (current.Size() % 2) == 0 ? current.Size() + 1 : current.Size();
            int localNumRows = (current.Size() % 2) == 0 ? 3 : 4;
            int currentRow = 0;
            List<List<PixelProgram>> split = current.Split();
            foreach (List<PixelProgram> rowOfPrograms in split)
            {
                for (int x = 0; x < localNumRows; x++)
                {
                    explodedProgramInput.Add("");
                }
                foreach (PixelProgram prog in rowOfPrograms)
                {
                    string mod = "";
                    List<string> permutations = prog.AllRotationsAndFlips();
                    foreach (string permutation in permutations)
                    {
                        if (rules.ContainsKey(permutation))
                            mod = rules[permutation];
                    }

                    if (mod == "")
                        throw new ArgumentException("Not found in rules");
                    string[] modSplit = mod.Split('/');
                    for (int y = 0; y < localNumRows; y++)
                    {
                        explodedProgramInput[currentRow + y] += modSplit[y];
                    }
                }
                currentRow += localNumRows;
            }

            // Now combine them
            string combined = string.Join("/", explodedProgramInput.ToArray());
            return new PixelProgram(combined);
        }

        private Dictionary<string, string> CreateRules(string filePath)
        {
            Dictionary<string, string> rules = new Dictionary<string, string>();

            string line;
            StreamReader file = new StreamReader(filePath);

            // Iterate over each line in the input
            while ((line = file.ReadLine()) != null)
            {
                string[] lineSplit = line.Split(new string[] { " => " }, StringSplitOptions.None);
                rules.Add(lineSplit[0].Trim(), lineSplit[1].Trim());
            }
            file.Close();

            return rules;
        }
    }
}