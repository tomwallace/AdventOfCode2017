using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Twelve
{
    public class DayTwelve : IAdventProblemSet
    {
        public string Description()
        {
            return "Digital Plumber";
        }

        public int SortOrder()
        {
            return 12;
        }

        public string PartA()
        {
            string filePath = @"Twelve\DayTwelveInput.txt";
            return CalculateProgramsConnected(filePath).ToString();
        }

        public string PartB()
        {
            string filePath = @"Twelve\DayTwelveInput.txt";
            return CalculateNumberProgramGroups(filePath).ToString();
        }

        public int CalculateProgramsConnected(string filePath)
        {
            List<Program> programs = new List<Program>();
            List<int> ids = new List<int>();

            string line;
            StreamReader file = new StreamReader(filePath);

            // Iterate over each line in the input
            while ((line = file.ReadLine()) != null)
            {
                Program program = new Program(line);
                programs.Add(program);
                ids.Add(program.Id);
            }
            file.Close();

            return NumberProgramsConnected(ids, programs, 0).NumberConnected;
        }

        public int CalculateNumberProgramGroups(string filePath)
        {
            List<Program> programs = new List<Program>();
            List<int> ids = new List<int>();

            string line;
            StreamReader file = new StreamReader(filePath);

            // Iterate over each line in the input
            while ((line = file.ReadLine()) != null)
            {
                Program program = new Program(line);
                programs.Add(program);
                ids.Add(program.Id);
            }
            file.Close();

            int numberOfGroups = 0;
            int baseId = 0;
            do
            {
                ProgramConnectedState result = NumberProgramsConnected(ids, programs, baseId);
                ids = result.UnconnectedIdsRemaining;
                baseId = ids.FirstOrDefault();
                numberOfGroups++;
            } while (ids.Count > 0);

            return numberOfGroups;
        }

        private ProgramConnectedState NumberProgramsConnected(List<int> ids, List<Program> programs, int baseId)
        {
            int originalNumberIds = ids.Count;

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(baseId);

            do
            {
                int currentId = queue.Dequeue();

                if (ids.Contains(currentId))
                {
                    Program current = programs.Find(p => p.Id == currentId);

                    ids.Remove(current.Id);
                    foreach (int connectedId in current.ConnectedIds)
                    {
                        queue.Enqueue(connectedId);
                    }
                }
            } while (queue.Count > 0);

            // Return number that contain zero
            int numberConnected = originalNumberIds - ids.Count;
            return new ProgramConnectedState() { NumberConnected = numberConnected, UnconnectedIdsRemaining = ids };
        }
    }
}