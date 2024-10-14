int passCounter = int.Parse(Console.ReadLine());

Queue<string> trafficJam = new Queue<string>();

int allPassedCars = 0;
string input = Console.ReadLine();

while (input != "end")
{
    if (input != "green")
    {
        trafficJam.Enqueue(input);
    }
    else if (input == "green")
    {
        int currentPass = passCounter;

        while (trafficJam.Count > 0 && currentPass > 0)
        {
            Console.WriteLine($"{trafficJam.Dequeue()} passed!");
            currentPass--;
            allPassedCars++;
        }
    }

    input = Console.ReadLine();
}

Console.WriteLine($"{allPassedCars} cars passed the crossroads.");