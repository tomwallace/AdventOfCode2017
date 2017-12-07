using System;
using System.Collections.Generic;

namespace AdventOfCode2017.Seven
{
    public class Disc
    {
        public string Id { get; set; }

        public int Weight { get; set; }

        public int WeightSupported { get; set; }

        public bool HasChildren { get; private set; }

        public List<string> ConnectedDiscIds;

        public List<Disc> ConnectedDiscs;

        public Disc(string input)
        {
            ConnectedDiscs = new List<Disc>();
            ConnectedDiscIds = new List<string>();
            WeightSupported = 0;

            string[] splitSpace = input.Split(' ');
            Id = splitSpace[0];
            Weight = Int32.Parse(splitSpace[1].Replace("(", "").Replace(")", ""));

            string[] splitArrow = input.Split(new string[] { "->" }, StringSplitOptions.None);
            if (splitArrow.Length > 1)
            {
                string[] ids = splitArrow[1].Split(',');
                foreach (string id in ids)
                {
                    ConnectedDiscIds.Add(id.Trim());
                }
            }

            HasChildren = ConnectedDiscIds.Count > 0;
        }

        // Used in tests
        public Disc(string id, int weight, List<string> connectedDiscIds)
        {
            Id = id;
            Weight = weight;
            ConnectedDiscIds = connectedDiscIds;
            ConnectedDiscs = new List<Disc>();
            WeightSupported = 0;

            HasChildren = ConnectedDiscIds.Count > 0;
        }
    }
}