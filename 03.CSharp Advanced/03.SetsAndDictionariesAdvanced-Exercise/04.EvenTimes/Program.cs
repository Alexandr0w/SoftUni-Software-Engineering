int n = int.Parse(Console.ReadLine());

Dictionary<int, int> frequency = new Dictionary<int, int>();

for (int i = 0; i < n; i++)
{
    int num = int.Parse(Console.ReadLine());

    if (frequency.ContainsKey(num))
    {
        frequency[num]++;
    }
    else
    {
        frequency[num] = 1;
    }
}

foreach (var pair in frequency)
{
    if (pair.Value % 2 == 0)
    {
        Console.WriteLine(pair.Key);
        break;
    }
}