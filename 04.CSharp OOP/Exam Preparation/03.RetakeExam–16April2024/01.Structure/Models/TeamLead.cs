using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models
{
    public class TeamLead : TeamMember
    {
        private static readonly List<string> AllowedPath = new() { "Master" };

        public TeamLead(string name, string path) : base(name, path)
        {
            if (!AllowedPath.Contains(path)) throw new ArgumentException(ExceptionMessages.PathIncorrect);
        }

        public override string ToString() => $"{this.Name} ({this.GetType().Name}) - {base.ToString()}";
    }
}
