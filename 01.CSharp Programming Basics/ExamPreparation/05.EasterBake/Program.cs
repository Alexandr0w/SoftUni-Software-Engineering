int numberOfEasterBreads = int.Parse(Console.ReadLine());

int totalSugar = 0;
int totalFlour = 0;
int maxUsedSugar = int.MinValue;
int maxUsedFlour = int.MinValue;

for (int i = 0; i < numberOfEasterBreads; i++)
{
    int sugarPerBread = int.Parse(Console.ReadLine());
    int flourPerBread = int.Parse(Console.ReadLine());

    totalSugar += sugarPerBread;
    totalFlour += flourPerBread;

    if (sugarPerBread > maxUsedSugar)
    {
        maxUsedSugar = sugarPerBread;
    }

    if (flourPerBread > maxUsedFlour)
    {
        maxUsedFlour = flourPerBread;
    }
}

int sugarPackages = (int)Math.Ceiling((double)totalSugar / 950);
int flourPackages = (int)Math.Ceiling((double)totalFlour / 750);

Console.WriteLine($"Sugar: {sugarPackages}");
Console.WriteLine($"Flour: {flourPackages}");
Console.WriteLine($"Max used flour is {maxUsedFlour} grams, max used sugar is {maxUsedSugar} grams.");