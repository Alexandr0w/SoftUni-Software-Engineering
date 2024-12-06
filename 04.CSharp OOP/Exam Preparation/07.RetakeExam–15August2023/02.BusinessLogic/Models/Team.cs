using Handball.Models.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handball.Models
{
    public class Team : ITeam
    {
        private List<IPlayer> _players;
        public Team(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(ExceptionMessages.TeamNameNull);

            this.Name = name;
            this.PointsEarned = 0;

            this._players = new List<IPlayer>();
            this.Players = this._players.AsReadOnly();
        }

        public string Name { get; }
        public int PointsEarned { get; private set; }
        public double OverallRating => this.Players.Count == 0 ? 0 : Math.Round(this._players.Average(p => p.Rating), 2);

        public IReadOnlyCollection<IPlayer> Players { get; }

        public void SignContract(IPlayer player) => this._players.Add(player);

        public void Win()
        {
            this.PointsEarned += 3;

            foreach (var player in this._players)
            {
                player.IncreaseRating();
            }
        }

        public void Lose()
        {
            foreach (var player in this._players)
            {
                player.DecreaseRating();
            }
        }

        public void Draw()
        {
            this.PointsEarned += 1;

            this.Players.FirstOrDefault(p => p.GetType().Name == nameof(Goalkeeper)).IncreaseRating();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Team: {this.Name} Points: {this.PointsEarned}");
            sb.AppendLine($"--Overall rating: {this.OverallRating}");
            sb.Append($"--Players: ");

            if (this.Players.Any())
            {
                var names = this.Players.Select(p => p.Name);
                sb.Append(string.Join(", ", names));
            }
            else
            {
                sb.Append("none");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
