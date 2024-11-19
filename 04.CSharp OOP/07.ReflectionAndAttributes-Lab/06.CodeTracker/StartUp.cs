using AuthorProblem;
using AuthorProblem.Attributes;
using System.Reflection;

namespace CodeTracker
{
    [Author("Victor")]
    public class StartUp
    {
        [Author("George")]
        public static void Main()
        {
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor(Assembly.GetExecutingAssembly());
        }
    }

}
