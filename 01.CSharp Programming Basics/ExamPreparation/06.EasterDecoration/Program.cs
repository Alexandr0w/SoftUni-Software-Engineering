using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        int numberOfClients = int.Parse(Console.ReadLine());
        double totalSpent = 0;

        for (int i = 0; i < numberOfClients; i++)
        {
            string command = Console.ReadLine();
            double price = 0;
            int itemsPurchased = 0;

            while (command != "Finish")
            {
                switch (command)
                {
                    case "basket":
                        price += 1.50;
                        break;
                    case "wreath":
                        price += 3.80;
                        break;
                    case "chocolate bunny":
                        price += 7.00;
                        break;
                }

                itemsPurchased++;
                command = Console.ReadLine();
            }

            if (itemsPurchased % 2 == 0)
            {
                // Добавяме отстъпка от 20% за четен брой покупки
                price *= 0.8;
            }

            totalSpent += price;

            Console.WriteLine($"You purchased {itemsPurchased} items for {price.ToString("F2", CultureInfo.InvariantCulture)} leva.");
        }

        double averageBillPerClient = totalSpent / numberOfClients;

        Console.WriteLine($"Average bill per client is: {averageBillPerClient.ToString("F2", CultureInfo.InvariantCulture)} leva.");
    }
}
