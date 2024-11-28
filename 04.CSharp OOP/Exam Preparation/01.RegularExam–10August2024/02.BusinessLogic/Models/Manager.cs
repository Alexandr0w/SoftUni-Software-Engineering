using FootballManager.Models.Contracts;
using FootballManager.Utilities.Messages;

namespace FootballManager.Models
{
    public abstract class Manager : IManager
    {
        private string _name;
        private double _ranking;

        protected Manager(string name, double ranking)
        {
            this.Name = name;
            this.Ranking = ranking;
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
                    throw new ArgumentException(ExceptionMessages.ManagerNameNull);
                }

                _name = value;
            }
        }

        public double Ranking
        {
            get
            {
                return _ranking;
            }
            protected set
            {
                _ranking = value;
            }
        }

        public abstract void RankingUpdate(double updateValue);

        public override string ToString() => $"{this.Name} - {this.GetType().Name} (Ranking: {this.Ranking:F2})";

        protected void UpdateRanking(double updateValue)
        {
            if (this.Ranking + updateValue > 100)
            {
                this.Ranking = 100;
                return;
            }
            else if (this.Ranking + updateValue < 0)
            {
                this.Ranking = 0;
                return;
            }

            this.Ranking += updateValue;
        }
    }
}