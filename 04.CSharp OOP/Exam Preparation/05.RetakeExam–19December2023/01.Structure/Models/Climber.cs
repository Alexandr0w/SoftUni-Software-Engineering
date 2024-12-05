using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities.Messages;
using System.Text;

namespace HighwayToPeak.Models
{
    public abstract class Climber : IClimber
    {
        private readonly List<string> _conqueredPeaks;

        protected Climber(string name, int stamina)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(ExceptionMessages.ClimberNameNullOrWhiteSpace);

            if (stamina < 0) stamina = 0;
            else if (stamina > 10) stamina = 10;
            else stamina = this.Stamina;

            this.Name = name;
            this.Stamina = stamina;

            this._conqueredPeaks = new List<string>();
            this.ConqueredPeaks = this._conqueredPeaks.AsReadOnly();
        }

        public string Name { get; }
        public int Stamina { get; protected set; }
        public IReadOnlyCollection<string> ConqueredPeaks { get; }

        public void Climb(IPeak peak)
        {
            if (this._conqueredPeaks.Contains(peak.Name))
            {
                this._conqueredPeaks.Add(peak.Name);
            }

            int tempStamina = 0;

            if (peak.DifficultyLevel == "Extreme") tempStamina += 6;
            else if (peak.DifficultyLevel == "Hard") tempStamina += 4;
            else tempStamina += 2;
        }

        public abstract void Rest(int daysCount);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name} - Name: {this.Name}, Stamina: {this.Stamina}");

            sb.Append("Peaks conquered: ");

            if (this._conqueredPeaks.Count > 0)
            {
                sb.AppendLine($"{ this.ConqueredPeaks.Count}");
            }
            else
            {
                sb.Append("no peaks conquered");
            }

            return sb.ToString().Trim();
        }
    }
}
