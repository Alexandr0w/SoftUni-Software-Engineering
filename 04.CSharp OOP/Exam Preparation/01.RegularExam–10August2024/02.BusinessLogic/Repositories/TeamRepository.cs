using FootballManager.Models.Contracts;
using FootballManager.Repositories.Contracts;

namespace FootballManager.Repositories
{
    public class TeamRepository : IRepository<ITeam>
    {
        private List<ITeam> _models;
        private int capacity = 10;

        public TeamRepository()
        {
            _models = new List<ITeam>();
        }

        public IReadOnlyCollection<ITeam> Models
        {
            get
            {
                return _models.AsReadOnly();
            }
        }

        public int Capacity
        {
            get
            {
                return capacity;
            }
        }

        public void Add(ITeam model)
        {
            if (_models.Count >= Capacity)
            {
                return;
            }

            _models.Add(model);
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
