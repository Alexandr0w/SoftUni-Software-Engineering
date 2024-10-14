int[] input = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

Stack<int> numbers = new Stack<int>(input);

while (true)
{
    string[] cmdArg = Console.ReadLine().Split();
    string command = cmdArg[0].ToLower();

    if (command == "end")
        break;

    if (command == "add")
    {
        int firstNum = int.Parse(cmdArg[1]);
        int secondNum = int.Parse(cmdArg[2]);

        numbers.Push(firstNum);
        numbers.Push(secondNum);
    }
    else if (command == "remove")
    {
        int count = int.Parse(cmdArg[1]);

        if (count <= numbers.Count)
        {
            for (int i = 0; i < count; i++)
            {
                numbers.Pop();
            }
        }

    }
}

Console.WriteLine($"Sum: {numbers.Sum()}");