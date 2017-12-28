namespace AdventOfCode2017.TwentyFour
{
    public class Component
    {
        public int Id { get; }

        public int FirstPort { get; }

        public int SecondPort { get; }

        public int Strength { get; }

        public Component(string input, int id)
        {
            string[] inputSplit = input.Split('/');
            
            FirstPort = int.Parse(inputSplit[0].Trim());
            SecondPort = int.Parse(inputSplit[1].Trim());

            Strength = FirstPort + SecondPort;

            Id = id;
        }

        public override string ToString()
        {
            return $"{FirstPort}|{SecondPort}";
        }
    }
}