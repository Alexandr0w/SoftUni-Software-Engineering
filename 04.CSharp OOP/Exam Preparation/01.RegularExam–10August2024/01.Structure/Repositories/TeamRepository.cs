using FootballManager.Models.Contracts;
using FootballManager.Repositories.Contracts;

namespace FootballManager.Repositories
{
    public class TeamRepository : IRepository<ITeam>
    {
        private int _capacity = 10;
        private readonly List<ITeam> _models;

        public TeamRepository()
        {
            this._models = new List<ITeam>();
            this.Models = this._models.AsReadOnly();
        }

        public IReadOnlyCollection<ITeam> Models { get; }
        public int Capacity { get; }

        public void Add(ITeam model)
        {
            if (_models.Count > this.Capacity) return;
            this._models.Add(model);
        }

        public bool Exists(string name)
        {
            ITeam? model = this._models.FirstOrDefault(x => x.Name == name);
            if (model == null) return false;    

            return true;
        }

        public ITeam Get(string name) => this._models.FirstOrDefault(x => x.Name == name)!;

        public bool Remove(string name)
        {
            ITeam? model = this._models.FirstOrDefault(x => x.Name == name);
            if (model == null) return false;

            return this._models.Remove(model);
        }
    }
}
