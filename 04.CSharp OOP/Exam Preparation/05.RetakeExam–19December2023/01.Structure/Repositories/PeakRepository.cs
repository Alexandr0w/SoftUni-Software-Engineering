using HighwayToPeak.Models;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;

namespace HighwayToPeak.Repositories
{
    public class PeakRepository : IRepository<IPeak>
    {
        private readonly List<IPeak> _peaks;

        public PeakRepository()
        {
            this._peaks = new List<IPeak>();
            this.All = this._peaks.AsReadOnly();
        }

        public IReadOnlyCollection<IPeak> All { get; }

        public void Add(IPeak model) => this._peaks.Add(model);

        public IPeak Get(string name) => this._peaks.FirstOrDefault(p => p.Name == name)!;
    }
}
