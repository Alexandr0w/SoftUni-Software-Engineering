namespace TheContentDepartment.Models
{
    public class Exam : Resource
    {
        private const int DefaultPriority = 1;

        public Exam(string name, string creator, int priority) : base(name, creator, DefaultPriority)
        {
        }
    }
}
