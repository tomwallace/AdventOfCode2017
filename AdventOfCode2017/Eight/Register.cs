namespace AdventOfCode2017.Eight
{
    public class Register
    {
        public string Name { get; set; }

        public int Value { get; set; }

        public Register(string name)
        {
            Name = name;
            Value = 0;
        }
    }
}