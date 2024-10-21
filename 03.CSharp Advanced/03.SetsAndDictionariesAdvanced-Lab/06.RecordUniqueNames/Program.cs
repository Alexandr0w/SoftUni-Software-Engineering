HashSet<string> names = new HashSet<string>();

int number = int.Parse(Console.ReadLine());
for (int i = 0; i < number; i++)
{
    names.Add(Console.ReadLine());
}

foreach (var name in names)
{
    Console.WriteLine(name);
}