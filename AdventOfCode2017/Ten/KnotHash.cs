using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2017.Ten
{
    public class KnotHash
    {
        public string HexOutput { get; }

        public KnotHash(List<int> input)
        {
            List<int> asciiCodes = ToAsciiCode(input);
            HexOutput = CommonHexConstructor(asciiCodes);
        }

        // Parameterless constructor needed for tests
        public KnotHash() { }

        public KnotHash(string input)
        {
            List<int> asciiCodes = ToAsciiCode(input);
            HexOutput = CommonHexConstructor(asciiCodes);
        }

        public List<int> ToAsciiCode(List<int> input)
        {
            string inputString = string.Join(",", input);

            return ToAsciiCode(inputString);
        }

        public List<int> ToAsciiCode(string inputString)
        {
            List<int> output = new List<int>();

            foreach (char c in inputString)
            {
                byte[] byteArray = Encoding.ASCII.GetBytes(c.ToString());
                foreach (byte b in byteArray)
                {
                    output.Add(b);
                }
            }
            return output;
        }

        public List<int> ToDenseHash(List<int> sparseHash, int totalInts)
        {
            int lower = 0;
            List<int> output = new List<int>();

            while ((lower + 16) <= totalInts)
            {
                List<int> subRange = sparseHash.GetRange(lower, 16);
                int calcXor = 0;
                foreach (int element in subRange)
                {
                    calcXor = calcXor ^ element;
                }
                output.Add(calcXor);

                lower += 16;
            }

            return output;
        }

        public string ToHexString(List<int> denseHash)
        {
            string output = "";
            foreach (int element in denseHash)
            {
                string toBeAdded = element.ToString("x");
                if (toBeAdded.Length < 2)
                    toBeAdded = $"0{toBeAdded}";

                output += toBeAdded;
            }

            return output;
        }

        private string CommonHexConstructor(List<int> asciiCodes)
        {
            List<int> extraCodes = new List<int>() { 17, 31, 73, 47, 23 };
            List<int> merged = asciiCodes.Concat(extraCodes).ToList();

            List<int> elements = Enumerable.Range(0, 256).ToList();
            KnotHashState previousState = new KnotHashState(elements, 0, 0);

            int counter = 0;
            while (counter < 64)
            {
                previousState = CalculateKnotHash(previousState, merged);
                counter++;
            }

            List<int> denseHash = ToDenseHash(previousState.Elements, 256);
            string hex = ToHexString(denseHash);
            return hex;
        }

        public KnotHashState CalculateKnotHash(KnotHashState previousState, List<int> inputs)
        {
            List<int> elements = previousState.Elements;
            int skipSize = previousState.SkipSize;
            int currentPosition = previousState.CurrentPosition;

            for (int length = 0; length < inputs.Count; length++)
            {
                int reverseTo = inputs[length];
                int reversePointer = 0;
                List<int> reversed = new List<int>();
                for (int x = 0; x < reverseTo; x++)
                {
                    int localPointer = currentPosition + x;
                    if (localPointer >= elements.Count)
                        localPointer = localPointer - elements.Count;

                    reversed.Add(elements[localPointer]);
                }

                reversed.Reverse();
                for (int y = 0; y < reverseTo; y++)
                {
                    int localPointer = currentPosition + y;
                    if (localPointer >= elements.Count)
                        localPointer = localPointer - elements.Count;

                    elements[localPointer] = reversed[reversePointer];
                    reversePointer++;
                }

                // Move the currentPosition forward by length
                currentPosition += (inputs[length] + skipSize);
                if (currentPosition >= elements.Count)
                    currentPosition = currentPosition % elements.Count;

                skipSize++;
            }

            return new KnotHashState(elements, currentPosition, skipSize);
        }
    }
}