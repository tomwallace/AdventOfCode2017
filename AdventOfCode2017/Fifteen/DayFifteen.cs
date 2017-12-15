namespace AdventOfCode2017.Fifteen
{
    public class DayFifteen : IAdventProblemSet
    {
        public static int GeneratorAInput = 634;
        public static int GeneratorBInput = 301;

        public static int GeneratorAFactor = 16807;
        public static int GeneratorBFactor = 48271;

        public string Description()
        {
            return "Dueling Generators";
        }

        public int SortOrder()
        {
            return 15;
        }

        public string PartA()
        {
            GeneratorStartingValuePair pair = new GeneratorStartingValuePair() { GeneratorA = GeneratorAInput, GeneratorB = GeneratorBInput };
            return NumberOfMatches(pair).ToString();
        }

        public string PartB()
        {
            GeneratorStartingValuePair pair = new GeneratorStartingValuePair() { GeneratorA = GeneratorAInput, GeneratorB = GeneratorBInput };
            return NumberOfMatchesJudgeWait(pair).ToString();
        }

        public int NumberOfMatches(GeneratorStartingValuePair startingValuePair)
        {
            Generator genA = new Generator(startingValuePair.GeneratorA, GeneratorAFactor, 1);
            Generator genB = new Generator(startingValuePair.GeneratorB, GeneratorBFactor, 1);

            int matches = 0;
            int iterations = 40000000;

            for (int i = 0; i < iterations; i++)
            {
                genA.NextValue();
                genB.NextValue();

                if (genA.IsEqual(genB))
                    matches++;
            }

            return matches;
        }

        public int NumberOfMatchesJudgeWait(GeneratorStartingValuePair startingValuePair)
        {
            Generator genA = new Generator(startingValuePair.GeneratorA, GeneratorAFactor, 4);
            Generator genB = new Generator(startingValuePair.GeneratorB, GeneratorBFactor, 8);

            int matches = 0;
            int iterations = 5000000;
            int counter = 0;

            string currentGenABinary = null;
            string currentGenBBinary = null;
            do
            {
                // Only advance them if they have not returned a value yet, otherwise wait for the other one
                if (currentGenABinary == null)
                {
                    genA.NextValue();
                    currentGenABinary = genA.CurrentBinary();
                }
                if (currentGenBBinary == null)
                {
                    genB.NextValue();
                    currentGenBBinary = genB.CurrentBinary();
                }

                if (currentGenABinary != null && currentGenBBinary != null)
                {
                    if (genA.IsEqual(genB))
                        matches++;

                    currentGenABinary = null;
                    currentGenBBinary = null;

                    counter++;
                }
            } while (counter < iterations);

            return matches;
        }
    }
}