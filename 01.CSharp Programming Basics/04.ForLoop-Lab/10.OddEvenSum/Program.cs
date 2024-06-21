int n = int.Parse(Console.ReadLine());

int sumEven = 0;
int sumOdd = 0;

for (int i = 1; i <= n; i++)
{
    int num = int.Parse(Console.ReadLine());

    if (i % 2 == 0)
    {
        sumOdd += num;
    }
    else
    {
        sumEven += num;
    }
}

if (sumEven == sumOdd)
{
    Console.WriteLine("Yes");
    Console.WriteLine("Sum = " + sumEven);
}
else
{
    Console.WriteLine("No");
    Console.WriteLine("Diff = " + Math.Abs(sumEven - sumOdd));
}