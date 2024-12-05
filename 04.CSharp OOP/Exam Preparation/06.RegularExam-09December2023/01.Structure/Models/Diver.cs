using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;

namespace NauticalCatchChallenge.Models
{
    public abstract class Diver : IDiver
    {
        private int _oxygenLevel;
        private double _competitionPoints;
        private bool hasHealthIssues;
        private readonly List<string> _catch;

        public Diver(string name, int oxygenLevel)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(ExceptionMessages.DiversNameNull);

            this.Name = name;
            this.OxygenLevel = oxygenLevel;

            this._catch = new List<string>();
            this.Catch = this._catch.AsReadOnly();

            this._competitionPoints = 0;
            this.hasHealthIssues = false;
        }

        public string Name { get; }
        public int OxygenLevel
        {
            get => _oxygenLevel;
            protected set
            {
                _oxygenLevel = Math.Max(value, 0);
            }
        }

        public IReadOnlyCollection<string> Catch { get; }
        public double CompetitionPoints => Math.Round(_competitionPoints, 1);
        public bool HasHealthIssues { get; }

        public void Hit(IFish fish)
        {
            this.OxygenLevel -= fish.TimeToCatch;
            this._catch.Add(fish.Name);
            this._competitionPoints += Math.Round(fish.Points, 1, MidpointRounding.AwayFromZero);
        }

        public abstract void Miss(int timeToCatch);

        public abstract void RenewOxy();

        public void UpdateHealthStatus() => this.hasHealthIssues = !this.HasHealthIssues;

        public override string ToString() 
            => $"Diver [ Name: {this.Name}, Oxygen left: {this.OxygenLevel}, Fish caught: {this.Catch.Count}, Points earned: {this.CompetitionPoints} ]";
    }
}
