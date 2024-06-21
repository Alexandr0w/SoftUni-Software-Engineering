int n = int.Parse(Console.ReadLine());

double TotalLiters = 0;
double GradusPerLiter = 0;
for (int i = 1; i < n+1; i++)
{ 
    double litersRakia = double.Parse(Console.ReadLine());
    double gradusRakia = double.Parse(Console.ReadLine());

    TotalLiters += litersRakia;
    GradusPerLiter = GradusPerLiter + litersRakia * gradusRakia;
}

double average = GradusPerLiter / TotalLiters;

Console.WriteLine($"Liter: {TotalLiters:F2}");
Console.WriteLine($"Degrees: {average:F2}");
if (average < 38)
{
    Console.WriteLine("Not good, you should baking!");
}
else if (average > 38 && average < 42)
{
    Console.WriteLine("Super!");
}
else if (average > 42)
{
    Console.WriteLine("Dilution with distilled water!");
}