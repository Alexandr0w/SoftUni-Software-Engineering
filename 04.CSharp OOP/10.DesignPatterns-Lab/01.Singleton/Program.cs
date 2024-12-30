namespace Singleton
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Before singleton creation");

            for (int i = 0; i < 100; i++)
            {
                new Thread(() =>
                {
                    LoggedUserSingleton.Instance.Username = "Alexander" + i;
                }).Start();
            }


            Console.WriteLine(LoggedUserSingleton.Instance.Username);
        }
    }
}
