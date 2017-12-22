using System;

namespace AdventOfCode2017.Twenty
{
    public class Particle
    {
        private Coordinate _position;
        private Coordinate _acceleration;
        private Coordinate _velocity;

        public int Id { get; }

        public Particle(string input, int id)
        {
            Id = id;

            // example: p=<5528,2008,1661>, v=<-99,-78,-62>, a=<-17,-2,-2>
            string[] inputSplit = input.Split('<');

            string pos = inputSplit[1].Split('>')[0].Trim();
            string[] posSplit = pos.Split(',');
            _position = new Coordinate(long.Parse(posSplit[0]), long.Parse(posSplit[1]), long.Parse(posSplit[2]));

            string vel = inputSplit[2].Split('>')[0].Trim();
            string[] velSplit = vel.Split(',');
            _velocity = new Coordinate(long.Parse(velSplit[0]), long.Parse(velSplit[1]), long.Parse(velSplit[2]));

            string acc = inputSplit[3].Split('>')[0].Trim();
            string[] accSplit = acc.Split(',');
            _acceleration = new Coordinate(long.Parse(accSplit[0]), long.Parse(accSplit[1]), long.Parse(accSplit[2]));
        }

        public void Update()
        {
            _velocity.X += _acceleration.X;
            _velocity.Y += _acceleration.Y;
            _velocity.Z += _acceleration.Z;

            _position.X += _velocity.X;
            _position.Y += _velocity.Y;
            _position.Z += _velocity.Z;
        }

        public long ManhattanDistance()
        {
            return Math.Abs(_position.X) + Math.Abs(_position.Y) + Math.Abs(_position.Z);
        }

        public override string ToString()
        {
            string coords = $"{_position.X}{_position.Y}{_position.Z}";
            return coords;
        }

        public override bool Equals(object obj)
        {
            ParticleComparer comparer = new ParticleComparer();
            return comparer.Equals(this, (Particle)obj);
        }

        public override int GetHashCode()
        {
            ParticleComparer comparer = new ParticleComparer();
            return comparer.GetHashCode(this);
        }
    }
}