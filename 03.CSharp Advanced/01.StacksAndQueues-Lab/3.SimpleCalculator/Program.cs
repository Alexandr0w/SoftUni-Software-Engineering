// 2 + 5 + 10 - 2 - 1

string[] input = Console.ReadLine()
    .Split()
    .Reverse()
    .ToArray();

Stack<string> calculator = new Stack<string>(input);

int result = int.Parse(calculator.Pop());

while (calculator.Count > 0)
{
    string operation = calculator.Pop();

    if (operation == "+")
    {
        result += int.Parse(calculator.Pop());
    }
    else if (operation == "-")
    {
        result -= int.Parse(calculator.Pop());
    }
}

Console.WriteLine(result);