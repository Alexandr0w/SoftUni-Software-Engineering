//Input
int startQuantity = int.Parse(Console.ReadLine());

//Solution
string input;

int soldEggsCounter = 0;
while ((input = Console.ReadLine()) != "Close")
{
    int eggCount = int.Parse(Console.ReadLine());

    if (input == "Buy")
    {
        if (eggCount > startQuantity)
        {
            Console.WriteLine("Not enough eggs in store!");
            Console.WriteLine($"You can buy only {startQuantity}.");
            break;
        }

        startQuantity -= eggCount;
        soldEggsCounter += eggCount;
    }
    else if (input == "Fill")
    {
        startQuantity += eggCount;
    }
}

if (input == "Close")
{
    Console.WriteLine("Store is closed!");
    Console.WriteLine($"{soldEggsCounter} eggs sold.");
}