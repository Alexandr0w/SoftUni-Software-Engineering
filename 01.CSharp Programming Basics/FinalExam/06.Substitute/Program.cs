using System;

class Program
{
    static void Main()
    {
        int K = int.Parse(Console.ReadLine());
        int L = int.Parse(Console.ReadLine());
        int M = int.Parse(Console.ReadLine());
        int N = int.Parse(Console.ReadLine());

        int validChangesCount = 0;

        for (int firstDigitFirstNumber = K; firstDigitFirstNumber <= 8; firstDigitFirstNumber ++)
        {
            for (int secondDigitFirstNumber = 9; secondDigitFirstNumber >= L; secondDigitFirstNumber--)
            {
                for (int firstDigitSecondNumber = M; firstDigitSecondNumber <= 8; firstDigitSecondNumber ++)
                {
                    for (int secondDigitSecondNumber = 9; secondDigitSecondNumber >= N; secondDigitSecondNumber--)
                    {
                        if(firstDigitFirstNumber % 2 == 0 && secondDigitFirstNumber % 2 != 0 && firstDigitSecondNumber % 2 == 0 && secondDigitSecondNumber % 2 != 0)
                        {
                            if (firstDigitFirstNumber == firstDigitSecondNumber && secondDigitFirstNumber == secondDigitSecondNumber)
                            {
                                Console.WriteLine("Cannot change the same player.");
                            }
                            else
                            {
                                Console.WriteLine($"{firstDigitFirstNumber}{secondDigitFirstNumber} - {firstDigitSecondNumber}{secondDigitSecondNumber}");
                                validChangesCount++;
                            }

                        }
                        if (validChangesCount == 6)
                        {
                            return;
                        }
                    }
                }
            }
        }
    }
}
