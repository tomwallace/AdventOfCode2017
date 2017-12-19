using System;

namespace AdventOfCode2017.Sixteen
{
    public class Partner : IDanceCommand
    {
        private readonly char _first;
        private readonly char _second;

        public Partner(string input)
        {
            // ex: pa/b
            string trimmed = input.Substring(1);
            string[] split = trimmed.Split('/');
            _first = split[0].ToCharArray()[0];
            _second = split[1].ToCharArray()[0];
        }

        public string Execute(string dancers)
        {
            char[] dancersArray = dancers.ToCharArray();
            int indexFirst = FindIndex(dancersArray, _first);
            int indexSecond = FindIndex(dancersArray, _second);
            dancersArray[indexFirst] = _second;
            dancersArray[indexSecond] = _first;

            return new string(dancersArray);
        }

        private int FindIndex(char[] array, char target)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == target)
                    return i;
            }

            throw new ArgumentOutOfRangeException();
        }
    }
}