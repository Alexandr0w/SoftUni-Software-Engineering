using System.Text.RegularExpressions;

namespace _05.NetherRealms
{
    internal class Program
    {
        class Demon
        {
            public string Name { get; set; }
            public int Health { get; set; }
            public decimal Damage { get; set; }

            public Demon(string name, int health, decimal damage)
            {
                Name = name;
                Health = health;
                Damage = damage;
            }
        }
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] demonPatterns = input.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            List<Demon> sortedDemons = new List<Demon>();

            foreach (string demonName in demonPatterns)
            {
                int health = CalculateHealth(demonName);
                decimal damage = CalculateDamage(demonName);

                Demon demon = new Demon(demonName, health, damage);
                sortedDemons.Add(demon);
            }

            sortedDemons = sortedDemons.OrderBy(d => d.Name).ToList();

            foreach (Demon demon in sortedDemons)
            {
                Console.WriteLine($"{demon.Name} - {demon.Health} health, {demon.Damage:F2} damage");
            }
        }

        static int CalculateHealth(string demonName)
        {
            int health = 0;

            string wordPattern = @"[^0-9\*\/\+\-\.]"; // All ASCI chars except 0-9\*\/\+\-\.
            MatchCollection matches = Regex.Matches(demonName, wordPattern);

            foreach (Match match in matches)
            {
                health += match.Value[0];
            }

            return health;
        }

        static decimal CalculateDamage(string demonName)
        {
            decimal damage = 0;

            string numberBasePattern = @"(?:(?:[-+]*)(?:\d+\.\d+|\d+))"; // all numbers (int/float) with possible prefix +/- 
            string multiplyPattern = @"[\*\/]"; // all * or /

            MatchCollection matches = Regex.Matches(demonName, numberBasePattern);

            foreach (Match match in matches)
            {
                decimal number;
                decimal.TryParse(match.Value, out number);
                damage += number;
            }

            matches = Regex.Matches(demonName, multiplyPattern);
            foreach (Match match in matches)
            {
                switch (match.Value)
                {
                    case "/":
                        damage /= 2;
                        break;
                    case "*":
                        damage *= 2;
                        break;
                }
            }

            return damage;
        }
    }
}
