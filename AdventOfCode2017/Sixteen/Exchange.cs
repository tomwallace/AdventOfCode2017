namespace AdventOfCode2017.Sixteen
{
    public class Exchange : IDanceCommand
    {
        private readonly int _firstIndex;
        private readonly int _secondIndex;

        public Exchange(string input)
        {
            // ex: x3/4
            string trimmed = input.Substring(1);
            string[] split = trimmed.Split('/');
            _firstIndex = int.Parse(split[0]);
            _secondIndex = int.Parse(split[1]);
        }

        public string Execute(string dancers)
        {
            char[] dancersArray = dancers.ToCharArray();
            char first = dancersArray[_firstIndex];
            char second = dancersArray[_secondIndex];
            dancersArray[_firstIndex] = second;
            dancersArray[_secondIndex] = first;

            return new string(dancersArray);
        }
    }
}