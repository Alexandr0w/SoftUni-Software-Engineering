using FootballManager.Models.Contracts;
using FootballManager.Utilities.Messages;

namespace FootballManager.Models
{
    public abstract class Manager : IManager
    {
        protected Manager(string name, double ranking)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ExceptionMessages.TeamNameNull);
            }

            Name = name;
            Ranking = ranking;
        }

        public string Name { get; }
        public double Ranking { get; protected set; }

        public abstract void RankingUpdate(double updateValue);

        protected void UpdateRanking(double updateValue)
        {
            if (Ranking + updateValue > 100)
            {
                Ranking = 100;
                return;
            }
            else if (Ranking + updateValue < 0)
            {
                Ranking = 0;
                return;
            }

            Ranking += updateValue;
        }

        public override string ToString() => $"{Name} - {GetType().Name} (Ranking: {Ranking:F2})";
    }
}
