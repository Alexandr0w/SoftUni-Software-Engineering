using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;

namespace HighwayToPeak.Repositories
{
    public class ClimberRepository : IRepository<IClimber>
    {
        private readonly List<IClimber> _climbers;
        public ClimberRepository()
        {
            this._climbers = new List<IClimber>();
            this.All = this._climbers.AsReadOnly();
        }

        public IReadOnlyCollection<IClimber> All { get; }

        public void Add(IClimber model) => this._climbers.Add(model);

        public IClimber Get(string name) => this._climbers.FirstOrDefault(p => p.Name == name)!;
    }
}
