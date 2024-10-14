// 1 + (2 - (2 + 3) * 4 / (3 + 1)) * 5

string input = Console.ReadLine();

Stack<int> indexes = new Stack<int>();

for (int i = 0; i < input.Length; i++)
{
    if (input[i] == '(')
    {
        indexes.Push(i);
    }
    else if (input[i] == ')')
    {
        int lastOpenBrackets = indexes.Pop();
        string result = input.Substring(lastOpenBrackets, i - lastOpenBrackets + 1);
        Console.WriteLine(result);
    }
}