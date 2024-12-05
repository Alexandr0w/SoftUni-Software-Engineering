namespace HighwayToPeak.Models
{
    using HighwayToPeak.Models.Contracts;
    using HighwayToPeak.Utilities.Messages;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Climber : IClimber
    {
        private int _stamina;
        private List<string> _conqueredPeaks;

        protected Climber(string name, int stamina)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(ExceptionMessages.ClimberNameNullOrWhiteSpace);

            this.Name = name;
            this.Stamina = stamina;

            this._conqueredPeaks = new List<string>();
            this.ConqueredPeaks = this._conqueredPeaks.AsReadOnly();
        }

        public string Name { get; }
        public int Stamina
        {
            get => _stamina;
            protected set
            {
                if (value < 0) _stamina = 0;
                else if (value > 10) _stamina = 10;
                else _stamina = value;
            }
        }

        public IReadOnlyCollection<string> ConqueredPeaks { get; }

        public void Climb(IPeak peak)
        {
            if (!_conqueredPeaks.Contains(peak.Name))
            {
                this._conqueredPeaks.Add(peak.Name);
            }            

            int tempStamina = 0;

            if (peak.DifficultyLevel == "Extreme")
            {
                tempStamina += 6;
            }
            else if (peak.DifficultyLevel == "Hard")
            {
                tempStamina += 4;
            }
            else
            {
                tempStamina += 2;
            }

            this.Stamina -= tempStamina;
        }

        public abstract void Rest(int daysCount);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name} - Name: {Name}, Stamina: {Stamina}");
            sb.Append("Peaks conquered: ");

            if(this._conqueredPeaks.Count > 0)
            {
                sb.AppendLine($"{ConqueredPeaks.Count}");
            }
            else
            {
                sb.Append("no peaks conquered");
            }

            return sb.ToString().Trim();
        }
    }
}
