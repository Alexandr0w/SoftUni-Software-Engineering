using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamGenerator
{
    public class Team
    {
        private readonly Dictionary<string, Player> _players;

        public Team(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("A name should not be empty.");
            }
            this.Name = name;

            this._players = new Dictionary<string, Player>();
            this.Players = new ReadOnlyDictionary<string, Player>(this._players);
        }

        public string Name { get; }
        public IReadOnlyDictionary<string, Player> Players { get; }

        public int Rating => this.CalculateRating();


        public void AddPlayer(Player player)
        {
            if (player is null) throw new ArgumentNullException(nameof(player));

            this._players[player.Name] = player;
        }

        public bool RemovePlayer(string playerName) => this._players.Remove(playerName);

        private int CalculateRating()
        {
            if (this.Players.Count == 0) return 0;
            return (int)Math.Round(this.Players.Values.Average(p => p.SkillLevel));
        }
    }
}
