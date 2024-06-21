int firstNumber = int.Parse(Console.ReadLine());
int secondNumber = int.Parse(Console.ReadLine());

for (int num = firstNumber; num <= secondNumber; num++)
{
    string currentNumber = num.ToString();

    int evenSum = 0;
    int oddSum = 0;

    for (int i = 0; i < currentNumber.Length; i++)
    {
        if (i % 2 == 0)
        { 
            evenSum += currentNumber[i];
        }
        else
        {
            oddSum += currentNumber[i];
        }
    }
    if (evenSum == oddSum)
    {
        Console.Write(currentNumber + " ");

    }
}