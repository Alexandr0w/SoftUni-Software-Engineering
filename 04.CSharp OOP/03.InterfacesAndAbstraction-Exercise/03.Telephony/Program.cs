namespace Telephony
{
    public class Program
    {
        public static void Main()
        {
            StationaryPhone stationaryPhone = new StationaryPhone();
            SmartPhone smartPhone = new SmartPhone();

            string[] phoneNumbers = Console.ReadLine()!.Split();
            string[] urls = Console.ReadLine()!.Split();

            Call(phoneNumbers, pn =>
            {
                if (pn.Length == 7) return stationaryPhone;
                if (pn.Length == 10) return smartPhone;
                return null;
            });
            Browse(urls, smartPhone);

        }

        private static void Call(string[] phoneNumbers, Func<string, ICaller?> provideCaller)
        {
            foreach (string phoneNumber in phoneNumbers)
            {
                if (!Call(phoneNumber, provideCaller))
                {
                    Console.WriteLine("Invalid number!");
                }
            }
        }

        private static bool Call(string phoneNumber, Func<string, ICaller?> provideCaller)
        {
            if (phoneNumber.Any(s => !char.IsDigit(s))) return false;
            
            ICaller? caller = provideCaller(phoneNumber);
            if (caller is null) return false;
            Console.WriteLine(caller.Call(phoneNumber));
                
            return true;
        }

        private static void Browse(string[] urls, IBrowser browser)
        {
            foreach (string url in urls)
            {
                if (!Browse(url, browser))
                {
                    Console.WriteLine("Invalid URL!");
                }
            }
        }

        private static bool Browse(string url, IBrowser browser)
        {
            if (url.Any(char.IsDigit)) return false;

            Console.WriteLine(browser.Browse(url));

            return true;
        }
    }
}