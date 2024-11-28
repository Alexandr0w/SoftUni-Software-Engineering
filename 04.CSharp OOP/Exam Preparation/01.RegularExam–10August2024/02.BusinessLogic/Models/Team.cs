using FootballManager.Models.Contracts;
using FootballManager.Utilities.Messages;

namespace FootballManager.Models
{
    public class Team : ITeam
    {
        private string _name;
        private int _championshipPoints;
        private IManager _teamManager;

        public Team(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return _name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.TeamNameNull);
                }

                _name = value;
            }
        }

        public int ChampionshipPoints
        {
            get
            {
                return _championshipPoints;
            }
            private set
            {
                _championshipPoints = value;
            }
        }

        public IManager TeamManager
        {
            get
            {
                return _teamManager;
            }
            private set
            {
                _teamManager = value;
            }
        }
        public int PresentCondition
        {
            get
            {
                if (this.TeamManager == null)
                {
                    return 0;
                }
                if (_championshipPoints == 0)
                {
                    return (int)this.TeamManager.Ranking;
                }
                int condition = (int)(ChampionshipPoints * this.TeamManager.Ranking);

                return condition;
            }
        }

        public void GainPoints(int points) => this.ChampionshipPoints += points;

        public void ResetPoints() => this.ChampionshipPoints = 0;

        public void SignWith(IManager manager) => this.TeamManager = manager;

        public override string ToString() => $"Team: {this.Name} Points: {this.ChampionshipPoints}";
    }
}