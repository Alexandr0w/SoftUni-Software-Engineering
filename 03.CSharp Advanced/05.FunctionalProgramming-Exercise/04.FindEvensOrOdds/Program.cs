int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
int lowerNumber = numbers[0];
int upperNumber = numbers[1];

string parity = Console.ReadLine();

Predicate<int> isValid = x => x % 2 == 0;

for (int i = lowerNumber; i < upperNumber; i++)
{
    if (parity == "even")
    else if (parity == "odd")
}    