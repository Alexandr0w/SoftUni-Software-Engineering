namespace Singleton
{
    public class LoggedUserSingleton
    {
        private static LoggedUserSingleton instance;
        private static object lockObject = new object();

        private LoggedUserSingleton()
        {
            Console.WriteLine("Singleton created!");
        }

        public static LoggedUserSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock(lockObject) 
                    {
                        if (instance == null)
                        {
                            instance = new LoggedUserSingleton();
                        }
                    }
                }

                return instance;
            }
        }

        public string Username { get; set; }
    }
}
