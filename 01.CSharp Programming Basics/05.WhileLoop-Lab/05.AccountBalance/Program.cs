string input = Console.ReadLine();
double sum = 0;

while (input != "NoMoreMoney")
{
    double fee = double.Parse(input);

    if (fee < 0)
    {
        Console.WriteLine("Invalid operation!");
        break;
    }
    Console.WriteLine($"Increase: {fee:f2}");
    sum += fee;

    input = Console.ReadLine();
}

Console.WriteLine($"Total: {sum:f2}");