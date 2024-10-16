Func<int, int, int> minFunc = (x, y) =>
{
    if (x < y) return x;
    else return y;
};

int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

int min = int.MaxValue;
for (int i = 0; i < numbers.Length; i++)
{
    min = minFunc(min, numbers[i]);
}

Console.WriteLine(min);