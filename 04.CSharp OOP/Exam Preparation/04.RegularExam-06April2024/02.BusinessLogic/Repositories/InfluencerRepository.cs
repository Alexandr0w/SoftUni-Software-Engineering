using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;

namespace InfluencerManagerApp.Repositories
{
    public class InfluencerRepository : IRepository<IInfluencer>
    {
        private readonly List<IInfluencer> _models;

        public InfluencerRepository()
        {
            this._models = new List<IInfluencer>();
            this.Models = this._models.AsReadOnly();
        }

        public IReadOnlyCollection<IInfluencer> Models { get; }

        public void AddModel(IInfluencer model)
            => this._models.Add(model);

        public bool RemoveModel(IInfluencer model)
            => this._models.Remove(model);

        public IInfluencer FindByName(string name)
            => this._models.FirstOrDefault(m => m.Username == name)!;
    }
}
