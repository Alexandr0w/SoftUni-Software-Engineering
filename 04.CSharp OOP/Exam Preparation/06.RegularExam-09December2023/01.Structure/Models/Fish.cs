using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;

namespace NauticalCatchChallenge.Models
{
    public abstract class Fish : IFish
    {
        protected Fish(string name, double points, int timeToCatch)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(ExceptionMessages.FishNameNull);
            if (points < 0 || points > 10) throw new ArgumentException(ExceptionMessages.PointsNotInRange);

            this.Name = name;
            this.Points = points;
            this.TimeToCatch = timeToCatch;
        }

        public string Name { get; }
        public double Points { get; }
        public int TimeToCatch { get; }

        public override string ToString() 
            => $"{this.GetType().Name}: {this.Name} [ Points: {this.Points}, Time to Catch: {this.TimeToCatch} seconds ]";
    }
}
