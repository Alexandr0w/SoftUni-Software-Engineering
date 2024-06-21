int n = int.Parse(Console.ReadLine());

int p1Count = 0;
int p2Count = 0;
int p3Count = 0;
int p4Count = 0;
int p5Count = 0;

for (int i = 0; i < n; i++)
{
    int num = int.Parse(Console.ReadLine());

    if (num < 200)
    {
        p1Count++;
    }
    else if (num >= 200 && num <= 399)
    {
        p2Count++;
    }
    else if (num >= 400 && num <= 599)
    {
        p3Count++;
    }
    else if (num >= 600 && num <= 799)
    {
        p4Count++;
    }
    else
    {
        p5Count++;
    }
}

double p1 = (double)p1Count / n * 100;
double p2 = (double)p2Count / n * 100;
double p3 = (double)p3Count / n * 100;
double p4 = (double)p4Count / n * 100;
double p5 = (double)p5Count / n * 100;

Console.WriteLine($"{p1:f2}%");
Console.WriteLine($"{p2:f2}%");
Console.WriteLine($"{p3:f2}%");
Console.WriteLine($"{p4:f2}%");
Console.WriteLine($"{p5:f2}%");