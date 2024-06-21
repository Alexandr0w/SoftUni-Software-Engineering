int n = int.Parse(Console.ReadLine());

int currentNumber = 1;
bool isBigger = false;

for (int row = 1; row <= n; row++)
{
    for (int col = 1; col <= row; col++)
    {
        if (currentNumber > n)
        {
            isBigger = true;
            break;
        }
        Console.Write($"{currentNumber} ");
        currentNumber++;
    }
    if(isBigger) 
    {
        break;
    }
    Console.WriteLine();
}
