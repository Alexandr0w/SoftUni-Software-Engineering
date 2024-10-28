using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamGenerator
{
    public class Player
    {
        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("A name should not be empty.");
            }

            this.Name = name;
            this.Endurance = ValidateStat(endurance, "Endurance");
            this.Sprint = ValidateStat(sprint, "Sprint");
            this.Dribble = ValidateStat(dribble, "Dribble");
            this.Passing = ValidateStat(passing, "Passing");
            this.Shooting = ValidateStat(shooting, "Shooting");
        }

        public string Name { get; }
        public int Endurance { get; }
        public int Sprint { get; }
        public int Dribble { get; }
        public int Passing { get; }
        public int Shooting { get; }

        public double SkillLevel => (this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5.0;

        private static int ValidateStat(int value, string statName)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{statName} should be between 0 and 100.");
            }

            return value;
        }
    }
}
