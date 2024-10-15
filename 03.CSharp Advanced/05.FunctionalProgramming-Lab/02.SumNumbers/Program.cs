Func<int[], int[]> sum = arr => new int[2] { arr.Count(), arr.Sum() };
int[] result = sum(Console.ReadLine().Split(",").Select(int.Parse).ToArray());
Console.WriteLine(string.Join(Environment.NewLine, result));