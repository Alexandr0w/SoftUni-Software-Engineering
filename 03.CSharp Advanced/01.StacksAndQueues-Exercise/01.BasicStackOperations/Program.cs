int[] parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
int n = parameters[0], s  = parameters[1], x = parameters[2];

int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();

Stack<int> stack = new Stack<int>();

for (int i = 0; i < n; i++)
{
    stack.Push(data[i]);
}

for (int i = 0; i < s; i++)
{
    stack.Pop();
}

if (stack.Count == 0)
{
    Console.WriteLine(0);
}

else if (stack.Contains(x))
{
    Console.WriteLine("true");
}

else
{
    Console.WriteLine(stack.Min());
}