int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
int lowerNumber = numbers[0];
int upperNumber = numbers[1];

string parity = Console.ReadLine();

Predicate<int> isValid;
if (parity == "even") isValid = x => x % 2 == 0;
else if (parity == "odd") isValid = x => x % 2 != 0;
else isValid = x => false;

List<int> result = new List<int>();
for (int i = lowerNumber; i <= upperNumber; i++)
{
    if (isValid(i))
    {
        result.Add(i);
    }
}

Console.WriteLine(string.Join(" ", result));