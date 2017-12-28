using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017.TwentyFive
{
    public class DayTwentyFive : IAdventProblemSet
    {
        public string Description()
        {
            return "The Halting Problem";
        }

        public int SortOrder()
        {
            return 25;
        }

        public string PartA()
        {
            return CalculateDiagnosticChecksum(GetStates(), 12683008, "A").ToString();
        }

        public string PartB()
        {
            return "There is no Part B for DayTwentyFive, as it is the last day. To get the last star, all the other stars must be complete.";
        }

        public long CalculateDiagnosticChecksum(Dictionary<string, TuringState> states, long steps, string startingStateKey)
        {
            Dictionary<long, bool> tape = new Dictionary<long, bool>();
            long currentLocation = 0;

            TuringState currentState = states[startingStateKey];
            if (currentState == null)
                throw new ArgumentException("Could not find starting state");

            long counter = 0;
            do
            {
                if (!tape.ContainsKey(currentLocation))
                    tape.Add(currentLocation, false);

                bool tapeValue = tape[currentLocation];
                tape[currentLocation] = currentState.Write(tapeValue);
                currentLocation += currentState.Move(tapeValue);

                currentState = states[currentState.NextStateKey(tapeValue)];
                if (currentState == null)
                    throw new ArgumentException("Could not find starting state");

                counter++;
            } while (counter < steps);

            return tape.Count(t => t.Value == true);
        }

        private Dictionary<string, TuringState> GetStates()
        {
            TuringState a = new TuringState(false, true, -1, 1, "B", "B");
            TuringState b = new TuringState(false, true, 1, -1, "E", "C");
            TuringState c = new TuringState(false, true, -1, 1, "D", "E");
            TuringState d = new TuringState(true, true, -1, -1, "A", "A");
            TuringState e = new TuringState(false, false, 1, 1, "F", "A");
            TuringState f = new TuringState(true, true, 1, 1, "A", "E");
            Dictionary<string, TuringState> states = new Dictionary<string, TuringState>();
            states.Add("A", a);
            states.Add("B", b);
            states.Add("C", c);
            states.Add("D", d);
            states.Add("E", e);
            states.Add("F", f);

            return states;
        }
    }
}