int n = int.Parse(Console.ReadLine());
int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

List<Func<int, bool>> divisibilityPredicates = new List<Func<int, bool>>();
for (int i = 0; i < numbers.Length; i++)
{
    int currentNumber = numbers[i];
    divisibilityPredicates.Add(x => x % currentNumber == 0);
}

IEnumerable<int> result = Enumerable.Range(1, n);

foreach (Func<int, bool> predicate in divisibilityPredicates)
{
    result = result.Where(predicate);
}

Console.WriteLine(string.Join(" ", result));