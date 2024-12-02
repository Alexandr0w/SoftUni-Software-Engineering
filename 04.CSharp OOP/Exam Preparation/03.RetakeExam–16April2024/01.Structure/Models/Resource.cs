using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models
{
    public abstract class Resource : IResource
    {
        protected Resource(string name, string creator, int priority)
        {
            if (String.IsNullOrWhiteSpace(name)) throw new ArgumentException(ExceptionMessages.NameNullOrWhiteSpace);

            this.Name = name;
            this.Creator = creator;
            this.Priority = priority;
        }

        public string Name { get; }
        public string Creator { get; }
        public int Priority { get; }
        public bool IsTested { get; private set; }
        public bool IsApproved { get; private set; }

        public void Approve() => this.IsApproved = true;

        public void Test() => this.IsTested = !this.IsTested;

        public override string ToString() => $"{this.Name} ({this.GetType().Name}), Created By: {this.Creator}";
    }
}
