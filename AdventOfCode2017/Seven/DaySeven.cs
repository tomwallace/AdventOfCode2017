using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Seven
{
    public class DaySeven : IAdventProblemSet
    {
        public string Description()
        {
            return "Recursive Circus";
        }

        public int SortOrder()
        {
            return 7;
        }

        public string PartA()
        {
            List<Disc> circus = GetCircusFromInputFile();

            return FindCircusRoot(circus);
        }

        public string PartB()
        {
            List<Disc> circus = GetCircusFromInputFile();

            return ProcessCircus(circus).ToString();
        }

        public string FindCircusRoot(List<Disc> circus)
        {
            List<string> allChildrenIds = new List<string>();
            foreach (Disc disc in circus)
            {
                allChildrenIds = allChildrenIds.Union(disc.ConnectedDiscIds).ToList();
            }

            Disc notContainedAsChild = circus.Find(d => !allChildrenIds.Contains(d.Id));

            return notContainedAsChild.Id;
        }

        public int ProcessCircus(List<Disc> circus)
        {
            LinkDiscs(circus);
            AssignWeightSupported(circus);

            // For large sets, this can include multiple arms, we want the smallest one, closest to leaves of the tree
            List<int> differencesInWeight = new List<int>();

            // Iterate over each disc with children, looking for ones with children with different weights
            List<Disc> withChildren = circus.FindAll(d => d.HasChildren).ToList();
            foreach (Disc disc in withChildren)
            {
                List<int> childWeights = disc.ConnectedDiscs.Select(c => c.WeightSupported).ToList();

                // If the weights are different, mark for evaluation
                if (childWeights.Distinct().Count() > 1)
                {
                    int deltaInWeightRange = childWeights.Max() - childWeights.Min();
                    int adjustmentToParentBaseWeight = disc.ConnectedDiscs.Find(c => c.WeightSupported == childWeights.Max()).Weight - deltaInWeightRange;
                    differencesInWeight.Add(adjustmentToParentBaseWeight);
                }
            }

            return differencesInWeight.Min();
        }

        private List<Disc> GetCircusFromInputFile()
        {
            List<Disc> circus = new List<Disc>();
            string line;
            StreamReader file = new StreamReader(@"Seven\DaySevenInput.txt");

            // Iterate over each line in the input
            while ((line = file.ReadLine()) != null)
            {
                circus.Add(new Disc(line));
            }
            file.Close();
            return circus;
        }

        private void AssignWeightSupported(List<Disc> circus)
        {
            foreach (Disc disc in circus)
            {
                disc.WeightSupported = RecurseToGetWeightSupported(disc);
            }
        }

        private int RecurseToGetWeightSupported(Disc current)
        {
            int weight = current.Weight;
            if (!current.HasChildren)
                return current.Weight;

            foreach (Disc child in current.ConnectedDiscs)
            {
                weight += RecurseToGetWeightSupported(child);
            }

            return weight;
        }

        private void LinkDiscs(List<Disc> circus)
        {
            foreach (Disc disc in circus)
            {
                foreach (string childId in disc.ConnectedDiscIds)
                {
                    Disc child = circus.Find(d => d.Id == childId);
                    disc.ConnectedDiscs.Add(child);
                }
            }
        }
    }
}