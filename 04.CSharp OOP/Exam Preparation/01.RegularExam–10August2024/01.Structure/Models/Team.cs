using FootballManager.Models.Contracts;
using FootballManager.Utilities.Messages;

namespace FootballManager.Models
{
    internal class Team : ITeam
    {
        private int _championshipPoints;

        public Team(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ExceptionMessages.TeamNameNull);
            }

            this.Name = name;
        }
        public string Name { get; }
        public int ChampionshipPoints { get; private set; }
        public IManager TeamManager { get; private set; }
        public int PresentCondition
        {
            get
            {
                if (TeamManager == null)
                {
                    return 0;
                }
                if (_championshipPoints == 0)
                {
                    return (int)TeamManager.Ranking;
                }
                int condition = (int)(ChampionshipPoints * TeamManager.Ranking);

                return condition;
            }
        }

        public void GainPoints(int points) => ChampionshipPoints += points;

        public void ResetPoints() => ChampionshipPoints = 0;

        public void SignWith(IManager manager) => TeamManager = manager;

        public override string ToString() => $"Team: {Name} Points: {ChampionshipPoints}";
    }
}
