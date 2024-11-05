namespace MoneyTransactions
{
    public class Program
    {
        static void Main()
        {
            string[] accountsData = Console.ReadLine()!.Split(",", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<int, double> accounts = new Dictionary<int, double>();

            foreach (string accountData in accountsData)
            {
                int accountNumber = int.Parse(accountData.Split("-")[0]);
                double accountBalance = double.Parse(accountData.Split("-")[1]);
                accounts.Add(accountNumber, accountBalance);
            }

            while (true)
            {
                bool hasException = false;

                string[] data = Console.ReadLine()!.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = data[0];

                if (command == "End")
                {
                    return;
                }

                int number = int.Parse(data[1]);
                double sum = double.Parse(data[2]);

                try
                {
                    switch (command)
                    {
                        case "Deposit":
                            Deposit(accounts, number, sum);
                            break;

                        case "Withdraw":
                            Withdraw(accounts, number, sum);
                            break;

                        default:
                            throw new ArgumentException("Invalid command!");
                    }
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("Invalid account!");
                    hasException = true;
                }
                catch (InvalidOperationException invEx)
                {
                    Console.WriteLine(invEx.Message);
                    hasException = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    hasException = true;
                }
                finally
                {
                    if (!hasException)
                    {
                        Console.WriteLine($"Account {number} has new balance: {accounts[number]:f2}");
                    }

                    Console.WriteLine("Enter another command");
                }
            }
        }

        private static void Withdraw(Dictionary<int, double> accounts, int number, double sum)
        {
            if (accounts[number] < sum)
            {
                throw new InvalidOperationException("Insufficient balance!");
            }

            accounts[number] -= sum;
        }

        private static void Deposit(Dictionary<int, double> accounts, int number, double sum) => accounts[number] += sum;
    }
}