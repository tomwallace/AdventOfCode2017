namespace AdventOfCode2017.Sixteen
{
    public class Spin : IDanceCommand
    {
        private readonly int _steps;

        public Spin(string input)
        {
            // ex: sX
            string stepInput = input.Substring(1);
            _steps = int.Parse(stepInput);
        }

        public string Execute(string input)
        {
            string output = "";
            int modInputLength = input.Length - _steps;
            for (int x = modInputLength; x < (modInputLength + input.Length); x++)
            {
                int index = x;
                if (index >= input.Length)
                    index = index - input.Length;

                output = $"{output}{input[index]}";
            }

            return output;
        }
    }
}