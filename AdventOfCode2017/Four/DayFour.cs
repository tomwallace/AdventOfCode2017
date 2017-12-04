using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Four
{
    public class DayFour
    {
        public long NumberValidPassPhrases()
        {
            long runningValidCount = 0;
            string line;
            StreamReader file = new StreamReader(@"Four\DayFourInput.txt");

            // Iterate over each line in the input
            while ((line = file.ReadLine()) != null)
            {
                if (IsValidPassPhrase_Duplicates(line))
                    runningValidCount++;
            }
            file.Close();

            return runningValidCount;
        }

        public long NumberValidPassPhrases_NoAnagrams()
        {
            long runningValidCount = 0;
            string line;
            StreamReader file = new StreamReader(@"Four\DayFourInput.txt");

            // Iterate over each line in the input
            while ((line = file.ReadLine()) != null)
            {
                if (IsValidPassPhrase_Duplicates(line) && IsValidPassPhrase_NoAnagrams(line))
                    runningValidCount++;
            }
            file.Close();

            return runningValidCount;
        }

        public bool IsValidPassPhrase_Duplicates(string line)
        {
            List<string> lineSplit = line.Split(' ').ToList();
            int count = lineSplit.Count;
            int uniqueCount = lineSplit.Distinct().Count();

            return count == uniqueCount;
        }

        public bool IsValidPassPhrase_NoAnagrams(string line)
        {
            List<string> lineSplit = line.Split(' ').ToList();

            for (int x = 0; x < lineSplit.Count; x++)
            {
                char[] xLetters = lineSplit[x].ToCharArray();
                for (int y = 0; y < lineSplit.Count; y++)
                {
                    if (x != y && lineSplit[x].Length == lineSplit[y].Length)
                    {
                        List<char> yLetters = lineSplit[y].ToCharArray().ToList();
                        // Iterate over and remove matches
                        foreach (char xLetter in xLetters)
                        {
                            if (yLetters.Contains(xLetter))
                                yLetters.Remove(xLetter);
                        }

                        // If no letters left, then invalid as direct match
                        if (yLetters.Count == 0)
                            return false;
                    }
                }
            }

            return true;
        }
    }
}