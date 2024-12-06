using Handball.Core.Contracts;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories;
using Handball.Utilities.Messages;
using System.Linq;
using System.Text;

namespace Handball.Core
{
    public class Controller : IController
    {
        private PlayerRepository _players;
        private TeamRepository _teams;

        public Controller()
        {
            this._players = new PlayerRepository();
            this._teams = new TeamRepository();
        }

        public string NewTeam(string name)
        {
            if (this._teams.ExistsModel(name))
            {
                return string.Format(OutputMessages.TeamAlreadyExists, name, nameof(TeamRepository));
            }

            this._teams.AddModel(new Team(name));

            return string.Format(OutputMessages.TeamSuccessfullyAdded, name, nameof(TeamRepository));
        }

        public string NewPlayer(string typeName, string name)
        {
            if (typeName != nameof(Goalkeeper) && typeName != nameof(CenterBack) && typeName != nameof(ForwardWing))
            {
                return string.Format(OutputMessages.InvalidTypeOfPosition, typeName);
            }

            if (this._players.ExistsModel(name))
            {
                var existingType = this._players.GetModel(name).GetType().Name;
                return string.Format(OutputMessages.PlayerIsAlreadyAdded, name, nameof(PlayerRepository), existingType);
            }

            IPlayer player;
            if (typeName == nameof(Goalkeeper)) player = new Goalkeeper(name);
            else if (typeName == nameof(CenterBack)) player = new CenterBack(name);
            else player = new ForwardWing(name);

            this._players.AddModel(player);

            return string.Format(OutputMessages.PlayerAddedSuccessfully, name);
        }

        public string NewContract(string playerName, string teamName)
        {
            if (!this._players.ExistsModel(playerName))
            {
                return string.Format(OutputMessages.PlayerNotExisting, playerName, nameof(PlayerRepository));
            }

            if (!this._teams.ExistsModel(teamName))
            {
                return string.Format(OutputMessages.TeamNotExisting, teamName, nameof(TeamRepository));
            }

            IPlayer player = this._players.GetModel(playerName);
            ITeam team = this._teams.GetModel(teamName);

            if (player.Team != null)
            {
                return string.Format(OutputMessages.PlayerAlreadySignedContract, playerName, player.Team);
            }

            player.JoinTeam(teamName);
            team.SignContract(player);

            return string.Format(OutputMessages.SignContract, playerName, teamName);
        }

        public string NewGame(string firstTeamName, string secondTeamName)
        {
            ITeam firstTeam = this._teams.GetModel(firstTeamName);
            ITeam secondTeam = this._teams.GetModel(secondTeamName);

            if (firstTeam.OverallRating != secondTeam.OverallRating)
            {
                ITeam winner;
                ITeam loser;

                if (firstTeam.OverallRating > secondTeam.OverallRating)
                {
                    winner = firstTeam;
                    loser = secondTeam;
                }
                else
                {
                    winner = secondTeam;
                    loser = firstTeam;
                }
                winner.Win();
                loser.Lose();

                return string.Format(OutputMessages.GameHasWinner, winner.Name, loser.Name);
            }
            else
            {
                firstTeam.Draw();
                secondTeam.Draw();

                return string.Format(OutputMessages.GameIsDraw, firstTeamName, secondTeamName);
            }
        }

        public string PlayerStatistics(string teamName)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"***{teamName}***");

            ITeam team = this._teams.GetModel(teamName);

            foreach (var player in team.Players.OrderByDescending(p => p.Rating).ThenBy(p => p.Name))
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().Trim();
        }

        public string LeagueStandings()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("***League Standings***");

            var sortedTeams = this._teams.Models
                .OrderByDescending(t => t.PointsEarned)
                .ThenByDescending(t => t.OverallRating)
                .ThenBy(t => t.Name);

            foreach (var team in sortedTeams)
            {
                sb.AppendLine(team.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
