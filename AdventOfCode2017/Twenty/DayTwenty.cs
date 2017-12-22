using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Twenty
{
    public class DayTwenty : IAdventProblemSet
    {
        public string Description()
        {
            return "Particle Swarm";
        }

        public int SortOrder()
        {
            return 20;
        }

        public string PartA()
        {
            string filePath = @"Twenty\DayTwentyInput.txt";
            return IdOfClosestParticle(filePath).ToString();
        }

        public string PartB()
        {
            string filePath = @"Twenty\DayTwentyInput.txt";
            return HowManyLeftAfterCollisions(filePath).ToString();
        }

        public int IdOfClosestParticle(string filePath)
        {
            List<Particle> particles = CreateParticles(filePath);

            int counter = 0;

            do
            {
                foreach (Particle particle in particles)
                {
                    particle.Update();
                }

                counter++;
            } while (counter < 1000);

            List<Particle> distances = particles.OrderBy(p => p.ManhattanDistance()).ToList();

            return distances[0].Id;
        }

        public int HowManyLeftAfterCollisions(string filePath)
        {
            List<Particle> particles = CreateParticles(filePath);

            int counter = 0;

            do
            {
                foreach (Particle particle in particles)
                {
                    particle.Update();
                }

                particles = ResolveCollisions(particles);
                counter++;
            } while (counter < 1000);

            return particles.Count;
        }

        private List<Particle> ResolveCollisions(List<Particle> particles)
        {
            var set = new HashSet<Particle>(particles);

            if (particles.Count != set.Count)
            {
                string[] duplicateKeys = particles.GroupBy(x => x.ToString())
                        .Where(group => group.Count() > 1)
                        .Select(group => group.Key).ToArray();

                foreach (string key in duplicateKeys)
                {
                    particles.RemoveAll(p => p.ToString() == key);
                }
            }

            return particles;
        }

        private List<Particle> CreateParticles(string filePath)
        {
            List<Particle> particles = new List<Particle>();
            int counter = 0;

            string line;
            StreamReader file = new StreamReader(filePath);

            // Iterate over each line in the input
            while ((line = file.ReadLine()) != null)
            {
                Particle particle = new Particle(line, counter);

                particles.Add(particle);
                counter++;
            }
            file.Close();
            return particles;
        }
    }
}