using BlackFriday.Models.Contracts;
using BlackFriday.Repositories.Contracts;

namespace BlackFriday.Repositories
{
    public class UserRepository : IRepository<IUser>
    {
        private List<IUser> _users;

        public UserRepository()
        {
            this._users = new List<IUser>();   
            this.Models = this._users.AsReadOnly();
        }

        public IReadOnlyCollection<IUser> Models { get; }

        public void AddNew(IUser model) => this._users.Add(model);

        public bool Exists(string name) => this._users.Any(m => m.UserName == name);

        public IUser GetByName(string name) => this._users.FirstOrDefault(m => m.UserName == name)!;
    }
}
