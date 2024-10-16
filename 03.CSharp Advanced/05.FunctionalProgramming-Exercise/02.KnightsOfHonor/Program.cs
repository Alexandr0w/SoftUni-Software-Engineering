Action<string> print = x => Console.WriteLine($"Sir {x}");

string[] values = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

for (int i = 0; i < values.Length; i++)
{
    print(values[i]);
}

/* string[] values = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
string sir = "Sir";

for (int i = 0; i < values.Length; i++)
{
    Console.WriteLine($"{sir} {values[i]}");
} */