namespace TheContentDepartment.Models
{
    public class Presentation : Resource
    {
        private const int DefaultPriority = 3;

        public Presentation(string name, string creator, int priority) : base(name, creator, DefaultPriority)
        {
        }
    }
}
