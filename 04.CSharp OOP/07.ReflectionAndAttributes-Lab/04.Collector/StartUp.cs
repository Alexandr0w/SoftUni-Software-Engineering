namespace Stealer
{
    public class StartUp
    {
        public static void Main()
        {
            Spy spy = new Spy();
            string result = spy.CollectingGettersAndSetters("Stealer.Hacker");
            Console.WriteLine(result);
        }
    }
}
