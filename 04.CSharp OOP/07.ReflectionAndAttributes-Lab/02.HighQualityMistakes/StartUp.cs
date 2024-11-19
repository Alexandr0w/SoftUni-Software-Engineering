namespace Stealer
{
    public class StartUp
    {
        public static void Main()
        {
            Spy spy = new Spy();
            Console.WriteLine(spy.AnalyzeAccessModifiers("Stealer.Hacker"));
        }
    }
}
