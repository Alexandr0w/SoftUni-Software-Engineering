int width = int.Parse(Console.ReadLine());
int length = int.Parse(Console.ReadLine());
int height = int.Parse(Console.ReadLine());

int freeSpace = width * length * height;

string input = Console.ReadLine();
while (input != "Done")
{
    int boxes = int.Parse(input);
    freeSpace -= boxes;

    if (freeSpace <= 0)
    {
        Console.WriteLine($"No more free space! You need {Math.Abs(freeSpace)} Cubic meters more.");
        return;
    }

    input = Console.ReadLine();
}

Console.WriteLine($"{freeSpace} Cubic meters left.");