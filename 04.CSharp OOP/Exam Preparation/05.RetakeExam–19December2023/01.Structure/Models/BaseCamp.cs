using HighwayToPeak.Models.Contracts;

namespace HighwayToPeak.Models
{
    public class BaseCamp : IBaseCamp
    {
        private List<string> _residents;

        public BaseCamp()
        {
            this._residents = new List<string>();
            this.Residents = this._residents.AsReadOnly();
        }

        public IReadOnlyCollection<string> Residents { get; }

        public void ArriveAtCamp(string climberName)
        {
            this._residents.Add(climberName);
            this._residents = this._residents.OrderBy(x => x).ToList();
        }

        public void LeaveCamp(string climberName) => this._residents.Remove(climberName);
    }
}
