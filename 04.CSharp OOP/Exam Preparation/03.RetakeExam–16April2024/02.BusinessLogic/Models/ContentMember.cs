using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models
{
    public class ContentMember : TeamMember
    {
        private static readonly List<string> AllowedPath = new() { "CSharp", "JavaScript", "Python", "Java" };
        public ContentMember(string name, string path) : base(name, path)
        {
            if (!AllowedPath.Contains(path)) throw new ArgumentException(string.Format(ExceptionMessages.PathIncorrect, path));
        }

        public override string ToString() => $"{this.Name} - {this.Path} path. {base.ToString()}";
    }
}
