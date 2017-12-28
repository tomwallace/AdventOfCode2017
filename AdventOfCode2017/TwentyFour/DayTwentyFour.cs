using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.TwentyFour
{
    public class DayTwentyFour : IAdventProblemSet
    {
        public string Description()
        {
            return "Electromagnetic Moat";
        }

        public int SortOrder()
        {
            return 24;
        }

        public string PartA()
        {
            string filePath = @"TwentyFour\DayTwentyFourInput.txt";
            List<BridgeState> states = FindStrengthOfStrongestBridge(filePath);
            return states.Select(s => s.TotalStrength).Max().ToString();
        }

        public string PartB()
        {
            string filePath = @"TwentyFour\DayTwentyFourInput.txt";
            List<BridgeState> states = FindStrengthOfStrongestBridge(filePath);
            List<BridgeState> sorted = states.OrderByDescending(c => c.TotalLength).ThenByDescending(c => c.TotalStrength).ToList();
            return sorted[0].TotalStrength.ToString();
        }

        public List<BridgeState> FindStrengthOfStrongestBridge(string filePath)
        {
            List<Component> components = MakeComponents(filePath);
            List<Component> potentialStarts = components.Where(c => c.FirstPort == 0 || c.SecondPort == 0).ToList();

            List<BridgeState> finalStates = new List<BridgeState>();

            Queue<BridgeState> stateQueue = new Queue<BridgeState>();

            foreach (Component start in potentialStarts)
            {
                int newOpenPort = start.FirstPort == 0 ? start.SecondPort : start.FirstPort;
                BridgeState startState = new BridgeState();
                startState.Current = start;
                startState.OpenPort = newOpenPort;
                startState.UsedIds.Add(start.Id);
                startState.TotalStrength = start.Strength;
                startState.TotalLength = 1;

                stateQueue.Enqueue(startState);
            }

            do
            {
                BridgeState currentState = stateQueue.Dequeue();
                List<Component> linkedComponents =
                    components.Where(
                        c =>
                            (c.FirstPort == currentState.OpenPort || c.SecondPort == currentState.OpenPort) &&
                            !currentState.UsedIds.Contains(c.Id)).ToList();

                if (linkedComponents.Count == 0)
                    finalStates.Add(currentState);

                foreach (Component linkedComponent in linkedComponents)
                {
                    BridgeState newState = new BridgeState();

                    List<int> newUsedIds = new List<int>();
                    foreach (int id in currentState.UsedIds)
                        newUsedIds.Add(id);
                    newUsedIds.Add(linkedComponent.Id);

                    int newOpenPort = linkedComponent.FirstPort == currentState.OpenPort
                        ? linkedComponent.SecondPort
                        : linkedComponent.FirstPort;

                    newState.UsedIds = newUsedIds;
                    newState.Current = linkedComponent;
                    newState.OpenPort = newOpenPort;
                    newState.TotalStrength = currentState.TotalStrength + linkedComponent.Strength;
                    newState.TotalLength = currentState.TotalLength + 1;

                    stateQueue.Enqueue(newState);
                }
            } while (stateQueue.Count > 0);

            return finalStates;
        }

        private List<Component> MakeComponents(string filePath)
        {
            List<Component> components = new List<Component>();
            string line;
            StreamReader file = new StreamReader(filePath);

            int counter = 0;

            // Iterate over each line in the input
            while ((line = file.ReadLine()) != null)
            {
                components.Add(new Component(line, counter));

                counter++;
            }
            file.Close();
            return components;
        }
    }
}