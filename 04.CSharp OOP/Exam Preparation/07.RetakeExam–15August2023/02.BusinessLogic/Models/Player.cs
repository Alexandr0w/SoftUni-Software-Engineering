using Handball.Models.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Text;

namespace Handball.Models
{
    public abstract class Player : IPlayer
    {
        protected Player(string name, double rating)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(ExceptionMessages.PlayerNameNull);

            this.Name = name;
            this.Rating = rating;
        }

        public string Name { get; }
        public double Rating { get; protected set; }
        public string Team { get; private set; }

        public void JoinTeam(string name) => this.Team = name;

        public abstract void DecreaseRating();

        public abstract void IncreaseRating();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}: {this.Name}");
            sb.AppendLine($"--Rating: {this.Rating}");

            return sb.ToString().TrimEnd();
        }
    }
}
