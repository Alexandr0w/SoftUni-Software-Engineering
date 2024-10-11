using OldestFamilyMember;

Family family = new Family();
int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

    Person currentMember = new Person(data[0], int.Parse(data[1])); 
    family.AddMember(currentMember);
}

Person oldestMember = family.GetOldestMember();
Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");