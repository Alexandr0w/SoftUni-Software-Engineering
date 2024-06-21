string nameOfActor = Console.ReadLine();
double academyPoints = double.Parse(Console.ReadLine());
int n = int.Parse(Console.ReadLine());

for (int i = 1; i <= n; i++)
{
    string jury = Console.ReadLine();
    double juryPoints = double.Parse(Console.ReadLine());

    academyPoints = academyPoints + ((jury.Length * juryPoints) / 2);

    if (academyPoints >= 1250.5)
    {
        Console.WriteLine($"Congratulations, {nameOfActor} got a nominee for leading role with {academyPoints:f1}!");
        break;
    }

}

if (academyPoints < 1250.5)
{
    Console.WriteLine($"Sorry, {nameOfActor} you need {1250.5 - academyPoints:f1} more!");
}